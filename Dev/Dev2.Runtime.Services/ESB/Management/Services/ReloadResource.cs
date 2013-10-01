﻿using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.Security;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    /// <summary>
    /// Reload a resource from disk ;)
    /// </summary>
    public class ReloadResource : IEsbManagementEndpoint
    {
        public string Execute(IDictionary<string, string> values, IWorkspace theWorkspace)
        {
            var result = new StringBuilder();

            string resourceID;
            string resourceType;

            values.TryGetValue("ResourceID", out resourceID);
            values.TryGetValue("ResourceType", out resourceType);

            try
            {
                // 2012.10.01: TWR - 5392 - Server does not dynamically reload resources 
                if(resourceID == "*")
                {
                    ResourceCatalog.Instance.LoadWorkspace(theWorkspace.ID);
                }
                else
                {
                    //
                    // Ugly conversion between studio resource type and server resource type
                    //
                    enDynamicServiceObjectType serviceType;
                    switch(resourceType)
                    {
                        case "HumanInterfaceProcess":
                        case "Website":
                        case "WorkflowService":
                            serviceType = enDynamicServiceObjectType.WorkflowActivity;
                            break;
                        case "Service":
                            serviceType = enDynamicServiceObjectType.DynamicService;
                            break;
                        case "Source":
                            serviceType = enDynamicServiceObjectType.Source;
                            break;
                        default:
                            throw new Exception("Unexpected resource type '" + resourceType + "'.");
                    }
                    Guid getID;
                    if(resourceID != null && Guid.TryParse(resourceID, out getID))
                    {
                        //
                        // Copy the file from the server workspace into the current workspace
                        //
                        theWorkspace.Update(
                            new WorkspaceItem(theWorkspace.ID, HostSecurityProvider.Instance.ServerID, Guid.Empty, getID)
                                {
                                    Action = WorkspaceItemAction.Edit,
                                    IsWorkflowSaved = true,
                                    ServiceType = serviceType.ToString()
                                }, false);
                            
                    }                      
                    else
                    {
                        theWorkspace.Update(
                            new WorkspaceItem(theWorkspace.ID, HostSecurityProvider.Instance.ServerID, Guid.Empty, Guid.Empty)
                            {
                                Action = WorkspaceItemAction.Edit,
                                ServiceName = resourceID,
                                IsWorkflowSaved = true,
                                ServiceType = serviceType.ToString()
                            }, false);
                    }
                    //
                    // Reload resources
                    //
                    ResourceCatalog.Instance.LoadWorkspace(theWorkspace.ID);
                    result.Append(string.Concat("'", resourceID, "' Reloaded..."));
                }
            }
            catch(Exception ex)
            {
                result.Append(string.Concat("Error reloading '", resourceID, "'..."));
                ServerLogger.LogError(ex);
            }

            return result.ToString();
        }

        public string HandlesType()
        {
            return "ReloadResourceService";
        }
        
        public DynamicService CreateServiceEntry()
        {
            DynamicService reloadResourceServicesBinder = new DynamicService();
            reloadResourceServicesBinder.Name = HandlesType();
            reloadResourceServicesBinder.DataListSpecification = "<DataList><ResourceID/><ResourceType/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>";

            ServiceAction reloadResourceServiceActionBinder = new ServiceAction();
            reloadResourceServiceActionBinder.Name = HandlesType();
            reloadResourceServiceActionBinder.SourceMethod = HandlesType();
            reloadResourceServiceActionBinder.ActionType = enActionType.InvokeManagementDynamicService;

            reloadResourceServicesBinder.Actions.Add(reloadResourceServiceActionBinder);

            return reloadResourceServicesBinder;
        }
    }
}
