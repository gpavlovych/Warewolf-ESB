﻿using System;
using System.Text;
using Dev2.Common;
using Dev2.Communication;
using Dev2.Data.Util;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.ESB.Management;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Execution
{
    /// <summary>
    /// Execute an internal or management service
    /// </summary>
    public class InternalServiceContainer : EsbExecutionContainer
    {

        public InternalServiceContainer(ServiceAction sa, IDSFDataObject dataObj, IWorkspace theWorkspace, IEsbChannel esbChannel, EsbExecuteRequest request) : base(sa, dataObj, theWorkspace, esbChannel, request)
        {

        }

        public override Guid Execute(out ErrorResultTO errors)
        {
            errors = new ErrorResultTO();
            var invokeErrors = new ErrorResultTO();
            Guid result = GlobalConstants.NullDataListID;

            try
            {
                EsbManagementServiceLocator emsl = new EsbManagementServiceLocator();
                IEsbManagementEndpoint eme = emsl.LocateManagementService(ServiceAction.Name);

                if(eme != null)
                {
                    // Web request for internal service ;)
                    if(Request.Args == null)
                    {
                        GenerateRequestDictionaryFromDataObject(out invokeErrors);
                        errors.MergeErrors(invokeErrors);
                    }

                    var res = eme.Execute(Request.Args, TheWorkspace);
                    Request.ExecuteResult = res;
                    errors.MergeErrors(invokeErrors);
                    result = DataObject.DataListID;
                    Request.WasInternalService = true;
                }
                else
                {
                    errors.AddError("Could not locate management service [ " + ServiceAction.ServiceName + " ]");
                }
            }
            catch(Exception ex)
            {
                errors.AddError(ex.Message);
            }

            return result;
        }

        private void GenerateRequestDictionaryFromDataObject(out ErrorResultTO errors)
        {
            var compiler = DataListFactory.CreateDataListCompiler();
            errors = new ErrorResultTO();

            ErrorResultTO invokeErrors;
            IBinaryDataList bdl = compiler.FetchBinaryDataList(DataObject.DataListID, out invokeErrors);
            errors.MergeErrors(invokeErrors);

            if(!invokeErrors.HasErrors())
            {
                foreach(IBinaryDataListEntry entry in bdl.FetchScalarEntries())
                {
                    IBinaryDataListItem itm = entry.FetchScalar();

                    if(!DataListUtil.IsSystemTag(itm.FieldName))
                    {
                        Request.AddArgument(itm.FieldName, new StringBuilder(itm.TheValue));
                    }
                }
            }
        }
    }
}
