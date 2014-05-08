﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Composition
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkflowExecutionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorkflowExecution.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkflowExecution", "In order to execute a workflow on the server\r\nAs a Warewolf user\r\nI want to be ab" +
                    "le to build workflows and execute them against the server", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WorkflowExecution")))
            {
                Dev2.Activities.Specs.Composition.WorkflowExecutionFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Simple workflow executing against the server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowExecution")]
        public virtual void SimpleWorkflowExecutingAgainstTheServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Simple workflow executing against the server", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given("I have a workflow \"WorkflowWithAssign\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table1.AddRow(new string[] {
                        "[[rec().a]]",
                        "yes"});
            table1.AddRow(new string[] {
                        "[[rec().a]]",
                        "no"});
#line 8
  testRunner.And("\"WorkflowWithAssign\" contains an Assign \"Rec To Convert\" as", ((string)(null)), table1, "And ");
#line 12
   testRunner.When("\"WorkflowWithAssign\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
   testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Variable",
                        "New Value"});
            table2.AddRow(new string[] {
                        "1",
                        "[[rec().a]] =",
                        "yes"});
            table2.AddRow(new string[] {
                        "2",
                        "[[rec().a]] =",
                        "no"});
#line 14
   testRunner.And("the \'Rec To Convert\' in WorkFlow \'WorkflowWithAssign\' debug inputs as", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table3.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = yes"});
            table3.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = no"});
#line 18
   testRunner.And("the \'Rec To Convert\' in Workflow \'WorkflowWithAssign\' debug outputs as", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Workflow with multiple tools executing against the server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowExecution")]
        public virtual void WorkflowWithMultipleToolsExecutingAgainstTheServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Workflow with multiple tools executing against the server", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
   testRunner.Given("I have a workflow \"WorkflowWithAssignAndCount\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table4.AddRow(new string[] {
                        "[[rec().a]]",
                        "yes"});
            table4.AddRow(new string[] {
                        "[[rec().a]]",
                        "no"});
#line 25
   testRunner.And("\"WorkflowWithAssignAndCount\" contains an Assign \"Rec To Convert\" as", ((string)(null)), table4, "And ");
#line 29
   testRunner.And("\"WorkflowWithAssignAndCount\" contains Count Record \"CountRec\" on \"[[rec()]]\" into" +
                    " \"[[count]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
   testRunner.When("\"WorkflowWithAssignAndCount\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
   testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Variable",
                        "New Value"});
            table5.AddRow(new string[] {
                        "1",
                        "[[rec().a]] =",
                        "yes"});
            table5.AddRow(new string[] {
                        "2",
                        "[[rec().a]] =",
                        "no"});
#line 32
   testRunner.And("the \'Rec To Convert\' in WorkFlow \'WorkflowWithAssignAndCount\' debug inputs as", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table6.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = yes"});
            table6.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = no"});
#line 36
   testRunner.And("the \'Rec To Convert\' in Workflow \'WorkflowWithAssignAndCount\' debug outputs as", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table7.AddRow(new string[] {
                        "[[rec(1).a]] = yes"});
            table7.AddRow(new string[] {
                        "[[rec(2).a]] = no"});
#line 40
   testRunner.And("the \'CountRec\' in WorkFlow \'WorkflowWithAssignAndCount\' debug inputs as", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table8.AddRow(new string[] {
                        "[[count]] = 2"});
#line 44
   testRunner.And("the \'CountRec\' in Workflow \'WorkflowWithAssignAndCount\' debug outputs as", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Simple workflow executing against the server with a database service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowExecution")]
        public virtual void SimpleWorkflowExecutingAgainstTheServerWithADatabaseService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Simple workflow executing against the server with a database service", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
  testRunner.Given("I have a workflow \"TestDbServiceWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input to Service",
                        "From Variable",
                        "Output from Service",
                        "To Variable"});
            table9.AddRow(new string[] {
                        "",
                        "",
                        "dbo_proc_SmallFetch(*).Value",
                        "[[rec().fetch]]"});
#line 50
  testRunner.And("\"TestDbServiceWF\" contains a database service \"Fetch\" with mappings", ((string)(null)), table9, "And ");
#line 53
  testRunner.And("\"TestDbServiceWF\" contains Count Record \"Count\" on \"[[rec()]]\" into \"[[count]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
   testRunner.When("\"TestDbServiceWF\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table10.AddRow(new string[] {
                        "",
                        ""});
#line 56
   testRunner.And("the \'Fetch\' in WorkFlow \'TestDbServiceWF\' debug inputs as", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table11.AddRow(new string[] {
                        "",
                        ""});
#line 59
   testRunner.And("the \'Fetch\' in Workflow \'TestDbServiceWF\' debug outputs as", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table12.AddRow(new string[] {
                        "[[rec(1).fetch]] = 1"});
            table12.AddRow(new string[] {
                        "[[rec(2).fetch]] = 2"});
            table12.AddRow(new string[] {
                        "[[rec(3).fetch]] = 1"});
            table12.AddRow(new string[] {
                        "[[rec(4).fetch]] = 2"});
            table12.AddRow(new string[] {
                        "[[rec(5).fetch]] = 1"});
            table12.AddRow(new string[] {
                        "[[rec(6).fetch]] = 2"});
            table12.AddRow(new string[] {
                        "[[rec(7).fetch]] = 1"});
            table12.AddRow(new string[] {
                        "[[rec(8).fetch]] = 2"});
            table12.AddRow(new string[] {
                        "[[rec(9).fetch]] = 5"});
#line 62
   testRunner.And("the \'Count\' in WorkFlow \'TestDbServiceWF\' debug inputs as", ((string)(null)), table12, "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table13.AddRow(new string[] {
                        "[[count]] = 9"});
#line 73
  testRunner.And("the \'Count\' in Workflow \'TestDbServiceWF\' debug outputs as", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion