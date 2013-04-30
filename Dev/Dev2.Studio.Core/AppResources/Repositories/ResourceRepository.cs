﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Dev2.Common;
using Dev2.Common.ExtMethods;
using Dev2.Composition;
using Dev2.DynamicServices;
using Dev2.Studio.Core.AppResources.Enums;
using Dev2.Studio.Core.AppResources.ExtensionMethods;
using Dev2.Studio.Core.Factories;
using Dev2.Studio.Core.InterfaceImplementors;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Utils;
using Dev2.Studio.Core.Wizards.Interfaces;
using Dev2.Workspaces;
using Unlimited.Framework;

namespace Dev2.Studio.Core.AppResources.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        readonly List<IResourceModel> _resourceModels;
        readonly List<string> _reservedServices;
        readonly IEnvironmentModel _environmentModel;
        readonly IFrameworkSecurityContext _securityContext;
        readonly IWizardEngine _wizardEngine;

        public event EventHandler ItemAdded;

        #region Constructor

        public ResourceRepository(IEnvironmentModel environmentModel)
            : this(environmentModel, ImportService.GetExportValue<IWizardEngine>())
        {
        }

        public ResourceRepository(IEnvironmentModel environmentModel, IWizardEngine wizardEngine)
        {
            if(wizardEngine == null)
            {
                throw new ArgumentNullException("wizardEngine");
            }
            _reservedServices = new List<string>();
            _resourceModels = new List<IResourceModel>();
            _environmentModel = environmentModel;
            _securityContext = environmentModel.Connection.SecurityContext;
            _wizardEngine = wizardEngine;
        }

        #endregion Constructor

        public bool IsLoaded { get; set; }
        public IWizardEngine WizardEngine { get { return _wizardEngine; } }

        #region Methods

        public void Load()
        {
            // BUG 9276 : TWR : 2013.04.19 - added IsLoaded check to prevent unnecessary loading of resources
            if(!IsLoaded)
            {
                IsLoaded = true;
                try
                {
                    _resourceModels.Clear();
                    AddResources(ResourceType.WorkflowService);
                    AddResources(ResourceType.Service);
                    AddResources(ResourceType.Source);
                    AddResources("ReservedService");
                }
                catch
                {
                    IsLoaded = false;
                }
            }
        }

        public void UpdateWorkspace(IList<IWorkspaceItem> workspaceItems)
        {
            IList<IWorkspaceItem> applicableWorkspaceItems = workspaceItems
                .Where(w => w.ServerID == ((IStudioClientContext)_environmentModel.DsfChannel).ServerID &&
                    w.WorkspaceID == ((IStudioClientContext)_environmentModel.DsfChannel).WorkspaceID)
                .ToList();

            var rootElement = new XElement("WorkspaceItems");
            rootElement.Add(applicableWorkspaceItems.Select(w => w.ToXml()));

            dynamic package = new UnlimitedObject();
            package.Service = "GetLatestService";
            package.EditedItemsXml = rootElement.ToString();
            package.Roles = string.Join(",", _securityContext.Roles);

            ExecuteCommand(_environmentModel, package);

            IsLoaded = false;
            Load();
        }

        public List<IResourceModel> ReloadResource(string resourceName, ResourceType resourceType, IEqualityComparer<IResourceModel> equalityComparer)
        {
            dynamic reloadPayload = new UnlimitedObject();
            reloadPayload.Service = "ReloadResourceService";
            reloadPayload.ResourceName = resourceName;
            reloadPayload.ResourceType = Enum.GetName(typeof(ResourceType), resourceType);

            ExecuteCommand(_environmentModel, reloadPayload);

            dynamic findPayload = new UnlimitedObject();
            findPayload.Service = "GetResourceService";
            findPayload.ResourceName = resourceName;
            findPayload.ResourceType = Enum.GetName(typeof(ResourceType), resourceType);
            findPayload.Roles = string.Join(",", _securityContext.Roles);

            var findResultObj = ExecuteCommand(_environmentModel, findPayload);

            var effectedResources = new List<IResourceModel>();
            var wfServices = (resourceType == ResourceType.Source) ? findResultObj.Source : findResultObj.Service;
            if (wfServices is List<UnlimitedObject>)
            {
                foreach (dynamic item in wfServices)
                {
                    IResourceModel resource = HydrateResourceModel(resourceType, item);
                    var resourceToUpdate = _resourceModels.FirstOrDefault(r => equalityComparer.Equals(r, resource));

                    if (resourceToUpdate != null)
                    {
                        resourceToUpdate.Update(resource);
                        effectedResources.Add(resourceToUpdate);
                    }
                    else
                    {
                        effectedResources.Add(resource);
                        _resourceModels.Add(resource);
                        if (ItemAdded != null)
                        {
                            ItemAdded(resource, null);
                        }
                    }
                }
            }

            return effectedResources;
        }

        /// <summary>
        /// Checks if a resources exists and is a workflow.
        /// </summary>
        public bool IsWorkflow(string resourceName)
        {
            IResourceModel match = All().FirstOrDefault(c => c.ResourceName.ToUpper().Equals(resourceName.ToUpper()));
            if (match != null)
            {
                return match.ResourceType == ResourceType.WorkflowService;
            }

            return false;
        }

        public bool IsReservedService(string resourceName)
        {
            return _reservedServices.Contains(resourceName.ToUpper());
        }

        public ICollection<IResourceModel> All()
        {
            return _resourceModels;
        }

        public ICollection<IResourceModel> Find(System.Linq.Expressions.Expression<Func<IResourceModel, bool>> expression)
        {
            Func<IResourceModel, bool> func = expression.Compile();
            return _resourceModels.FindAll(func.Invoke);
        }

        public IResourceModel FindSingle(System.Linq.Expressions.Expression<Func<IResourceModel, bool>> expression)
        {
            Func<IResourceModel, bool> func = expression.Compile();


            return _resourceModels.Find(func.Invoke);
        }

        public void Save(IResourceModel instanceObj)
        {
            var workflow = FindSingle(c => c.ResourceName.Equals(instanceObj.ResourceName, StringComparison.CurrentCultureIgnoreCase));
            if (workflow == null)
            {
                _resourceModels.Add(instanceObj);
            }

            dynamic package = new UnlimitedObject();
            package.Service = "AddResourceService";
            package.ResourceXml = instanceObj.ToServiceDefinition();
            package.Roles = string.Join(",", _securityContext.Roles);

            ExecuteCommand(_environmentModel, package, false);
        }

        public void DeployResource(IResourceModel resource)
        {
            IResourceModel workflow = FindSingle(c => c.ResourceName.Equals(resource.ResourceName, StringComparison.CurrentCultureIgnoreCase));
            if (workflow == null)
            {
                _resourceModels.Add(resource);
            }
            else
            {
                workflow.Update(resource);
            }

            dynamic package = new UnlimitedObject();
            package.Service = "DeployResourceService";
            package.ResourceXml = resource.ToServiceDefinition();
            package.Roles = string.Join(",", _securityContext.Roles ?? new string[0]);

            ExecuteCommand(_environmentModel, package, false);
        }

        public void Save(ICollection<IResourceModel> instanceObjs)
        {
            throw new NotImplementedException();
        }

        public void Remove(ICollection<IResourceModel> instanceObjs)
        {
            throw new NotImplementedException();
        }

        public void Remove(IResourceModel instanceObj)
        {
            DeleteResource(instanceObj);
        }

        public UnlimitedObject DeleteResource(IResourceModel resource)
        {
            int index = _resourceModels.IndexOf(resource);
            if (index != -1)
                _resourceModels.RemoveAt(index);
            else throw new KeyNotFoundException();

            var contextualResource = resource as IContextualResourceModel;
            if (contextualResource == null) return null;

            if (!_wizardEngine.IsWizard(contextualResource))
            {
                IContextualResourceModel wizard = _wizardEngine.GetWizard(contextualResource);
                if (wizard != null)
                {
                    UnlimitedObject wizardData = ExecuteDeleteResource(wizard);

                    if (wizardData.HasError)
                    {
                        HandleDeleteResourceError(wizardData, contextualResource);
                        return null;
                    }
                }
            }

            UnlimitedObject data = ExecuteDeleteResource(contextualResource);

            if (data.HasError)
            {
                HandleDeleteResourceError(data, contextualResource);
                return null;
            }

            return data;
        }

        private UnlimitedObject ExecuteDeleteResource(IContextualResourceModel resource)
        {
            dynamic request = new UnlimitedObject();
            request.Service = "DeleteResourceService";
            request.ResourceName = resource.ResourceName;
            request.ResourceType = resource.ResourceType.ToString();
            request.Roles = String.Join(",", _securityContext.Roles ?? new string[0]);

            return ExecuteCommand(resource.Environment, request);
        }

        //Juries TODO - Refactor to popupProvider
        private void HandleDeleteResourceError(dynamic data, IContextualResourceModel model)
        {
            if (data.HasError)
            {
                MessageBox.Show(Application.Current.MainWindow, model.ResourceType.GetDescription() + " \"" + model.ResourceName +
                                                                "\" could not be deleted, reason: " + data.Error,
                                model.ResourceType.GetDescription() + " Deletion Failed", MessageBoxButton.OK);
            }
        }

        public void Add(IResourceModel instanceObj)//Ashley Lewis: 15/01/2013 (for ResourceRepositoryTest.WorkFlowService_OnDelete_Expected_NotInRepository())
        {
            _resourceModels.Insert(_resourceModels.Count, instanceObj);
        }

        #endregion Methods

        #region Private Methods

        private void AddResources(string resourceType)
        {
            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "FindResourceService";
            dataObj.ResourceName = "*";
            dataObj.ResourceType = resourceType;
            dataObj.Roles = string.Join(",", _securityContext.Roles);

            var resultObj = ExecuteCommand(_environmentModel, dataObj);

            string xml = resultObj.XmlString;
            var index = 0;

            while ((index = xml.IndexOf("<ReservedName>", index, StringComparison.Ordinal)) != -1)
            {
                var start = index + 14;
                if ((index = xml.IndexOf("</ReservedName>", start, StringComparison.Ordinal)) == -1)
                {
                    break;
                }

                var length = index - start;
                var name = xml.Substring(start, length);
                _reservedServices.Add(name.ToUpper());
            }
        }

        private void AddResources(ResourceType resourceType)
        {
            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "FindResourceService";
            dataObj.ResourceName = "*";
            dataObj.ResourceType = Enum.GetName(typeof(ResourceType), resourceType);
            dataObj.Roles = string.Join(",", _securityContext.Roles);

            var resultObj = ExecuteCommand(_environmentModel, dataObj);

            dynamic wfServices = (resourceType == ResourceType.Source) ? resultObj.Source : resultObj.Service;
            if (wfServices is List<UnlimitedObject>)
            {
                foreach (dynamic item in wfServices)
                {
                    try
                    {
                        IResourceModel resource = HydrateResourceModel(resourceType, item);
                        _resourceModels.Add(resource);
                        if (ItemAdded != null)
                        {
                            ItemAdded(resource, null);
                        }
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                        // Ignore malformed resources
                        // TODO Log this
                    }
                }
            }
        }

        private IResourceModel HydrateResourceModel(ResourceType resourceType, dynamic data)
        {
            var resource = ResourceModelFactory.CreateResourceModel(_environmentModel);
            resource.ResourceType = resourceType;
            if (data.XamlDefinition is string)
            {
                if (!string.IsNullOrEmpty(data.XamlDefinition))
                {
                    resource.WorkflowXaml = data.XamlDefinition;
                    resource.ServiceDefinition = data.XmlString;
                }
            }

            resource.DataList = data.GetValue("DataList");
            resource.ID = Guid.Parse(data.GetValue("ID"));

            resource.ServerID = Guid.Parse(data.GetValue("ServerID"));

            resource.Version = Version.Parse(data.GetValue("Version"));

            if (string.IsNullOrEmpty(resource.ServiceDefinition))
            {
                resource.ServiceDefinition = data.XmlString;
            }

            if (data.DisplayName is string)
            {
                resource.DisplayName = data.DisplayName;
            }
            else
            {
                resource.DisplayName = resourceType.ToString();
            }

            if (data.IconPath is string)
            {
                resource.IconPath = data.IconPath;
            }

            if (data.AuthorRoles is string)
            {
                resource.AuthorRoles = data.AuthorRoles;
            }

            if (data.Category is string)
            {
                resource.Category = data.Category;
            }
            else
            {
                resource.Category = string.Empty;
            }

            if (data.Tags is string)
            {
                resource.Tags = data.Tags;
            }

            if (data.Comment is string)
            {
                resource.Comment = data.Comment;
            }

            if (data.UnitTestTargetWorkflowService is string)
            {
                resource.UnitTestTargetWorkflowService = data.UnitTestTargetWorkflowService;
            }

            if (data.HelpLink is string)
            {
                if (!string.IsNullOrEmpty(data.HelpLink))
                {
                    resource.HelpLink = data.HelpLink;
                }
            }

            if (data.IsNewWorkflow is string)
            {
                resource.IsNewWorkflow = false;
                if (data.IsNewWorkflow == "true")
                {
                    resource.IsNewWorkflow = true;
                    NewWorkflowNames.Instance.Add(resource.DisplayName);
                }
            }

            var service = resourceType == ResourceType.Source ? data.Source : data.Service;
            if (service is List<UnlimitedObject>)
            {
                foreach (dynamic svc in service)
                {

                    if (svc.Name is string)
                    {
                        resource.ResourceName = svc.Name;
                    }
                    else
                    {
                        // Travis : if we here it means Name is an element in the datalist
                        var tmpObj = (svc as UnlimitedObject);

                        // ReSharper disable PossibleNullReferenceException
                        var xDoc = new XmlDocument();
                        xDoc.LoadXml(tmpObj.XmlString);
                        var n = xDoc.SelectSingleNode("Service");
                        resource.ResourceName = n.Attributes["Name"].Value;
                        // ReSharper restore PossibleNullReferenceException
                    }
                }
            }

            return resource;
        }

        #endregion Private Methods

        #region Add/RemoveEnvironment

        public static void AddEnvironment(IEnvironmentModel targetEnvironment, IEnvironmentModel environment)
        {
            if (targetEnvironment == null)
            {
                throw new ArgumentNullException("targetEnvironment");
            }
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "AddResourceService";
            dataObj.ResourceXml = environment.ToSourceDefinition();
            dataObj.Roles = string.Join(",", environment.Connection.SecurityContext.Roles);

            ExecuteCommand(targetEnvironment, dataObj, false);
        }

        public static void RemoveEnvironment(IEnvironmentModel targetEnvironment, IEnvironmentModel environment)
        {
            if (targetEnvironment == null)
            {
                throw new ArgumentNullException("targetEnvironment");
            }
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "DeleteResourceService";
            dataObj.ResourceName = environment.Name;
            dataObj.ResourceType = ResourceType.Source.ToString();
            dataObj.Roles = string.Join(",", environment.Connection.SecurityContext.Roles);

            ExecuteCommand(targetEnvironment, dataObj, false);
        }

        #endregion

        #region FindResourcesByID

        public static List<UnlimitedObject> FindResourcesByID(IEnvironmentModel targetEnvironment, IEnumerable<string> guids, ResourceType resourceType)
        {
            if (targetEnvironment == null || guids == null)
            {
                return new List<UnlimitedObject>();
            }

            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "FindResourcesByID";
            dataObj.GuidCsv = string.Join(",", guids); // BUG 9276 : TWR : 2013.04.19 - reintroduced to all filtering
            dataObj.Type = Enum.GetName(typeof(ResourceType), resourceType);

            var resourcesObj = ExecuteCommand(targetEnvironment, dataObj);

            var result = new List<UnlimitedObject>();
            AddItems(result, resourceType == ResourceType.Source ? resourcesObj.Source : resourcesObj.Service);

            return result;
        }

        #endregion

        #region FindSourcesByType

        public static List<UnlimitedObject> FindSourcesByType(IEnvironmentModel targetEnvironment, enSourceType sourceType)
        {
            if (targetEnvironment == null)
            {
                return new List<UnlimitedObject>();
            }

            dynamic dataObj = new UnlimitedObject();
            dataObj.Service = "FindSourcesByType";
            dataObj.Type = Enum.GetName(typeof(enSourceType), sourceType);

            var resourcesObj = ExecuteCommand(targetEnvironment, dataObj);

            var result = new List<UnlimitedObject>();
            AddItems(result, resourcesObj.Source);

            return result;
        }

        #endregion

        #region AddItems

        static void AddItems(ICollection<UnlimitedObject> result, dynamic items)
        {
            if (items is IEnumerable<UnlimitedObject>)
            {
                foreach (var item in items)
                {
                    var itemObj = UnlimitedObject.GetStringXmlDataAsUnlimitedObject(item.XmlString);
                    result.Add(itemObj);
                }
            }
        }

        #endregion

        #region ExecuteCommand

        static dynamic ExecuteCommand(IEnvironmentModel targetEnvironment, UnlimitedObject dataObj, bool convertResultToUnlimitedObject = true)
        {
            var workspaceID = targetEnvironment.Connection.WorkspaceID;
            var result = targetEnvironment.Connection.ExecuteCommand(dataObj.XmlString, workspaceID, GlobalConstants.NullDataListID);

            if (result == null)
            {
                dynamic tmp = dataObj;
                throw new Exception(string.Format(GlobalConstants.NetworkCommunicationErrorTextFormat, tmp.Service));
            }

            if (convertResultToUnlimitedObject)
            {
                // PBI : 7913 -  Travis
                var resultObj = UnlimitedObject.GetStringXmlDataAsUnlimitedObject(result);
                if (resultObj.HasError)
                {
                    throw new Exception(resultObj.Error);
                }
                return resultObj;
            }
            return result;
        }

        #endregion

    }
}
