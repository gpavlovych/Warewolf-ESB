﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using Dev2.Common;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DataList.Contract.Builders;
using Dev2.DataList.Contract.Value_Objects;
using Dev2.Diagnostics;
using Dev2.Util;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;
using ThreadState = System.Diagnostics.ThreadState;

namespace Dev2.Activities
{
    public class DsfExecuteCommandLineActivity : DsfActivityAbstract<string>
    {
        #region Fields

        string _commandFileName;
        string _commandResult;

        #endregion
       
        /// <summary>
        /// Gets or sets the name of the recordset.
        /// </summary>  
        [Inputs("CommandFileName")]
        [FindMissing]
        public string CommandFileName
        {
            get
            {
                return _commandFileName;
            }
            set
            {
                _commandFileName = value;
            }
        }

        [Outputs("CommandResult")]
        [FindMissing]
        public string CommandResult
        {
            get
            {
                return _commandResult;
            }
            set
            {
                _commandResult = value;
            }
        }

        #region Overrides of DsfNativeActivity<string>

        public DsfExecuteCommandLineActivity()
            : base("Execute Command Line")
        {
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        /// <summary>
        /// When overridden runs the activity's execution logic
        /// </summary>
        /// <param name="context">The context to be used.</param>
        protected override void OnExecute(NativeActivityContext context)
        {
            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();

            Guid dlID = dataObject.DataListID;
            ErrorResultTO allErrors = new ErrorResultTO();
            ErrorResultTO errors = new ErrorResultTO();

            try
            {
                IBinaryDataListEntry expressionsEntry = compiler.Evaluate(dlID, enActionType.User, CommandFileName, false, out errors);
                if (dataObject.IsDebug || ServerLogger.ShouldLog(dataObject.ResourceID) || dataObject.RemoteInvoke)
                {
                    AddDebugInputItem(CommandFileName, "Command to execute", expressionsEntry, dlID);
                }
                allErrors.MergeErrors(errors);
                IDev2DataListEvaluateIterator itr = Dev2ValueObjectFactory.CreateEvaluateIterator(expressionsEntry);
                IDev2DataListUpsertPayloadBuilder<string> toUpsert = Dev2DataListBuilderFactory.CreateStringDataListUpsertBuilder(true);
                while (itr.HasMoreRecords())
                {
                    IList<IBinaryDataListItem> cols = itr.FetchNextRowData();
                    foreach (IBinaryDataListItem c in cols)
                    {
                        if (c.IsDeferredRead)
                        {
                            toUpsert.HasLiveFlushing = true;
                            toUpsert.LiveFlushingLocation = dlID;
                        }

                        if (!string.IsNullOrEmpty(c.TheValue))
                        {
                            string val = c.TheValue;
                            StreamReader errorReader;
                            StreamReader outputReader;
                            if(!ExecuteProcess(val, out errorReader, out outputReader)) return;

                            allErrors.AddError(errorReader.ReadToEnd());
                            string readValue = outputReader.ReadToEnd();
                            //2013.06.03: Ashley Lewis for bug 9498 - handle multiple regions in result
                            foreach (var region in DataListCleaningUtils.SplitIntoRegions(CommandResult))
                            {
                                toUpsert.Add(region, readValue);
                                if (dataObject.IsDebug || ServerLogger.ShouldLog(dataObject.ResourceID))
                                {
                                    AddDebugOutputItem(region, readValue, dlID);
                                }
                            }
                            errorReader.Close();
                            outputReader.Close();

                            if (toUpsert.HasLiveFlushing)
                            {
                                try
                                {
                                    toUpsert.FlushIterationFrame(true);
                                    toUpsert = null;
                                }
                                catch (Exception e)
                                {
                                    allErrors.AddError(e.Message);
                                }
                            }
                            else
                            {
                                compiler.Upsert(dlID, toUpsert, out errors);                                
                                allErrors.MergeErrors(errors);
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                allErrors.AddError(e.Message);
            }
            finally
            {
                // Handle Errors
                
                if (allErrors.HasErrors())
                {
                    DisplayAndWriteError("DsfExecuteCommandLineActivity", allErrors);
                    compiler.UpsertSystemTag(dlID, enSystemTag.Error, allErrors.MakeDataListReady(), out errors);
                }
                if (dataObject.IsDebug || ServerLogger.ShouldLog(dataObject.ResourceID) || dataObject.RemoteInvoke)
                {
                    DispatchDebugState(context,StateType.Before);
                    DispatchDebugState(context, StateType.After);
                }
            }
           
        }

        bool ExecuteProcess(string val, out StreamReader errorReader, out StreamReader outputReader)
        {
            using(var process = new Process())
            {
                var processStartInfo = CreateProcessStartInfo(val);
                
                if (processStartInfo == null) throw new ArgumentNullException("processStartInfo");

                process.StartInfo = processStartInfo;
                bool processStarted = process.Start();
                outputReader = process.StandardOutput;
                errorReader = process.StandardError;
                if(!ProcessHasStarted(processStarted, process))
                {
                    return false;
                }

                process.StandardInput.Close();
                Thread.Sleep(1000);

                while(!process.HasExited)
                {
                    if(!process.HasExited)
                    {
                        var isWaitingForUserInput = ModalChecker.IsWaitingForUserInput(process);
                        if (isWaitingForUserInput)
                        {
                            process.Kill();
                            throw new ApplicationException("The process required user input.");
                        }

                        //var processThread = process.Threads[0];

                        //if (processThread.ThreadState == ThreadState.Wait && processThread.WaitReason == ThreadWaitReason.UserRequest)
                        //{
                        //    process.Kill();
                        //    throw new ApplicationException("The process required user input.");
                        //}
                    }
                    
                    //CheckChildProcesses(process.Id);

                    Thread.Sleep(10);
                }
                process.Close();
            }
            return true;
        }

        //void CheckChildProcesses(int id)
        //{
        //     var searcher = new ManagementObjectSearcher("root\\CIMV2", string.Format("SELECT * FROM Win32_Process Where ParentProcessId={0}", id));

        //    var managementObjectCollection = searcher.Get();
        //    foreach(ManagementObject queryObj in managementObjectCollection)
        //    {
        //        var nameOfProcess = queryObj["Name"];
        //        var pid = Convert.ToInt32(queryObj["ProcessId"]);
        //        var processById = Process.GetProcessById(pid);
        //        processById.Kill();
        //        throw new ApplicationException(string.Format("Process tried to start another process {0}", nameOfProcess));
        //     }
        //}

        bool ProcessHasStarted(bool processStarted, Process process)
        {
            if(!processStarted)
            {
                CommandResult = "Command did not start. " + Environment.NewLine +
                                "Exit Code: " + process.ExitCode;
                return false;
            }
            return true;
        }

        ProcessStartInfo CreateProcessStartInfo(string val)
        {
            if(val.Contains("cmd")) throw new ArgumentException("Cannot execute CMD from tool.");
            if(val.Contains("explorer")) throw new ArgumentException("Cannot execute explorer from tool.");

            ProcessStartInfo psi = null;

            if (val.StartsWith("\""))
            {
                // we have a quoted string for the cmd portion
                var idx = val.IndexOf("\" \"", StringComparison.Ordinal);
                if (idx < 0)
                {
                    // account for "xxx" arg
                    idx = val.IndexOf("\" ", StringComparison.Ordinal);
                    if (idx < 0)
                    {
                        psi = new ProcessStartInfo(val);
                    }
                    else
                    {
                        var cmd = val.Substring(0, (idx+1)); // keep trailing "
                        var args = val.Substring((idx + 2));
                        psi = new ProcessStartInfo(cmd, args);
                    }
                }
                else
                {
                    var cmd = val.Substring(0, (idx+1)); // keep trailing "
                    var args = val.Substring((idx + 2));
                    psi = new ProcessStartInfo(cmd, args);
                }
            }
            else
            {
                // no quotes ;)
                var idx = val.IndexOf(" ", StringComparison.Ordinal);
                if (idx < 0)
                {
                    psi = new ProcessStartInfo(val);
                }
                else
                {
                    var cmd = val.Substring(0, idx);
                    var args = val.Substring((idx + 1));
                    psi = new ProcessStartInfo(cmd, args);
                }
            }

            if (psi != null)
            {
                psi.UseShellExecute = false;
                psi.ErrorDialog = false;
                psi.RedirectStandardError = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;   
            }

            return psi;
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
        }

        #region Overrides of DsfNativeActivity<string>

        public override List<DebugItem> GetDebugInputs(IBinaryDataList dataList)
        {
            foreach (IDebugItem debugInput in _debugInputs)
            {
                debugInput.FlushStringBuilder();
            }
            return _debugInputs;
        }

        public override List<DebugItem> GetDebugOutputs(IBinaryDataList dataList)
        {
            foreach (IDebugItem debugOutput in _debugOutputs)
            {
                debugOutput.FlushStringBuilder();
            }
            return _debugOutputs;
        }

        #endregion

        #region Private Methods

        private void AddDebugInputItem(string expression, string labelText, IBinaryDataListEntry valueEntry, Guid executionId)
        {
            DebugItem itemToAdd = new DebugItem();

            if (!string.IsNullOrWhiteSpace(labelText))
            {
                itemToAdd.Add(new DebugItemResult { Type = DebugItemResultType.Label, Value = labelText });
            }

            if (valueEntry != null)
            {
                itemToAdd.AddRange(CreateDebugItemsFromEntry(expression, valueEntry, executionId, enDev2ArgumentType.Input));
            }

            _debugInputs.Add(itemToAdd);
        }

        private void AddDebugOutputItem(string expression, string value, Guid dlId)
        {
            DebugItem itemToAdd = new DebugItem();
            itemToAdd.AddRange(CreateDebugItemsFromString(expression, value, dlId, 0, enDev2ArgumentType.Output));
            _debugOutputs.Add(itemToAdd);
        }

        #endregion

        #endregion
    }
}