using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Data.ServiceModel;
using Dev2.Data.Util;
using Dev2.DataList.Contract;
using Dev2.Diagnostics;
using Dev2.Runtime.Hosting;
using Dev2.TO;
using Microsoft.SharePoint.Client;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Storage;
using WarewolfParserInterop;

namespace Dev2.Activities.Sharepoint
{
    public class SharepointReadListActivity : DsfActivityAbstract<string>
    {

        public SharepointReadListActivity()
        {
            DisplayName = "Sharepoint Read List Item";
            ReadListItems = new List<SharepointReadListTo>();
            FilterCriteria = new List<SharepointSearchTo>();
            RequireAllCriteriaToMatch = true;
            _sharepointUtils = new SharepointUtils();
        }

        public IList<SharepointReadListTo> ReadListItems { get; set; }
        public Guid SharepointServerResourceId { get; set; }
        public string SharepointList { get; set; }
        public List<SharepointSearchTo> FilterCriteria { get; set; }
        public bool RequireAllCriteriaToMatch { get; set; }
        public SharepointUtils SharepointUtils
        {
            get
            {
                return _sharepointUtils;
            }
        }

        /// <summary>
        /// When overridden runs the activity's execution logic 
        /// </summary>
        /// <param name="context">The context to be used.</param>
        protected override void OnExecute(NativeActivityContext context)
        {
            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            ExecuteTool(dataObject);
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates)
        {
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates)
        {
        }

        public override IList<DsfForEachItem> GetForEachInputs()
        {
            return null;
        }

        public override IList<DsfForEachItem> GetForEachOutputs()
        {
            return null;
        }

        public override enFindMissingType GetFindMissingType()
        {
            return enFindMissingType.MixedActivity;
        }

        int _indexCounter = 1;
        readonly SharepointUtils _sharepointUtils;

        protected override void ExecuteTool(IDSFDataObject dataObject)
        {
            _debugInputs = new List<DebugItem>();
            _debugOutputs = new List<DebugItem>();
            _indexCounter = 1;
            ErrorResultTO allErrors = new ErrorResultTO();
            try
            {
                var sharepointReadListTos = _sharepointUtils.GetValidReadListItems(ReadListItems).ToList();
                if(sharepointReadListTos.Any())
                {
                    var sharepointSource = ResourceCatalog.Instance.GetResource<SharepointSource>(dataObject.WorkspaceID, SharepointServerResourceId);
                    if(sharepointSource == null)
                    {
                        var contents = ResourceCatalog.Instance.GetResourceContents(dataObject.WorkspaceID, SharepointServerResourceId);
                        sharepointSource = new SharepointSource(contents.ToXElement());
                    }
                    var env = dataObject.Environment;
                    if(dataObject.IsDebugMode())
                    {
                        AddInputDebug(env);
                    }
                    var sharepointHelper = sharepointSource.CreateSharepointHelper();
                    using(var ctx = sharepointHelper.GetContext())
                    {
                        var camlQuery = _sharepointUtils.BuildCamlQuery(env, FilterCriteria);
                        List list =  sharepointHelper.LoadFieldsForList(SharepointList, ctx,false);
                        var listItems = list.GetItems(camlQuery);
                        ctx.Load(listItems);
                        ctx.ExecuteQuery();
                        var index = 1;
                        foreach(var listItem in listItems)
                        {

                            foreach(var sharepointReadListTo in sharepointReadListTos)
                            {
                                var variableName = sharepointReadListTo.VariableName;
                                var fieldToName = sharepointReadListTo.FieldName;
                                var fieldName = list.Fields.FirstOrDefault(field => field.Title == fieldToName);
                                if(fieldName != null)
                                {
                                    var listItemValue = "";
                                    try
                                    {
                                        var sharepointValue = listItem[fieldName.InternalName];
                                        if(sharepointValue != null)
                                        {
                                            var userValue = sharepointValue as FieldUserValue;
                                            var fieldValue = sharepointValue as FieldLookupValue;
                                            if(userValue != null)
                                            {
                                                sharepointValue = userValue.LookupValue;
                                            }
                                            if(fieldValue != null)
                                            {
                                                sharepointValue = fieldValue.LookupValue;
                                            }
                                            listItemValue = sharepointValue.ToString();
                                        }
                                    }
                                    catch(Exception e)
                                    {
                                        Dev2Logger.Log.Error(e);
                                        //Ignore sharepoint exception on retrieval not all fields can be retrieved.
                                    }
                                    var correctedVariable = variableName;
                                    if (DataListUtil.IsValueRecordset(variableName) && DataListUtil.IsStarIndex(variableName))
                                    {
                                        correctedVariable = DataListUtil.ReplaceStarWithFixedIndex(variableName, index);
                                    }
                                    env.AssignWithFrame(new AssignValue(correctedVariable, listItemValue));
                                }
                            }
                            index++;
                        }
                    }
                    env.CommitAssign();
                    AddOutputDebug(dataObject, env);
                }
            }
            catch(Exception e)
            {
                Dev2Logger.Log.Error("SharepointReadListActivity", e);
                allErrors.AddError(e.Message);
            }
            finally
            {
                var hasErrors = allErrors.HasErrors();
                if(hasErrors)
                {
                    DisplayAndWriteError("SharepointReadListActivity", allErrors);
                    var errorString = allErrors.MakeDisplayReady();
                    dataObject.Environment.AddError(errorString);
                }
                if(dataObject.IsDebugMode())
                {
                    DispatchDebugState(dataObject, StateType.Before);
                    DispatchDebugState(dataObject, StateType.After);
                }
            }
        }

        void AddOutputDebug(IDSFDataObject dataObject, IExecutionEnvironment env)
        {
            if(dataObject.IsDebugMode())
            {
                var outputIndex = 1;
                var validItems = _sharepointUtils.GetValidReadListItems(ReadListItems).ToList();
                foreach (var varDebug in validItems)
                {
                    var debugItem = new DebugItem();
                    AddDebugItem(new DebugItemStaticDataParams("", outputIndex.ToString(CultureInfo.InvariantCulture)), debugItem);
                    var variable = varDebug.VariableName.Replace("().", "(*).");
                    AddDebugItem(new DebugEvalResult(variable, "", env), debugItem);
                    _debugOutputs.Add(debugItem);
                    outputIndex++;
                }
            }
        }

        void AddInputDebug(IExecutionEnvironment env)
        {
            var validItems = _sharepointUtils.GetValidReadListItems(ReadListItems).ToList();
            foreach (var varDebug in validItems)
            {
                DebugItem debugItem = new DebugItem();
                AddDebugItem(new DebugItemStaticDataParams("", _indexCounter.ToString(CultureInfo.InvariantCulture)), debugItem);
                var variableName = varDebug.VariableName;
                if(!string.IsNullOrEmpty(variableName))
                {
                    AddDebugItem(new DebugEvalResult(variableName, "Variable", env), debugItem);
                    AddDebugItem(new DebugItemStaticDataParams(varDebug.FieldName, "Field Name"), debugItem);
                }
                _indexCounter++;
                _debugInputs.Add(debugItem);
            }
        }

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment dataList)
        {
            foreach (IDebugItem debugInput in _debugInputs)
            {
                debugInput.FlushStringBuilder();
            }
            return _debugInputs;
        }

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment dataList)
        {
            foreach (IDebugItem debugOutput in _debugOutputs)
            {
                debugOutput.FlushStringBuilder();
            }
            return _debugOutputs;
        }

       
    }
}