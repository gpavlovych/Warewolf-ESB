﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Resources.Database
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MySqlConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MySqlConnector.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "MySqlConnector", "In order to manage my database services\r\nAs a Warewolf User\r\nI want to be shown t" +
                    "he database service setup", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "MySqlConnector")))
            {
                Dev2.Activities.Specs.Toolbox.Resources.Database.MySqlConnectorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating MySQL Connector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void CreatingMySQLConnector()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating MySQL Connector", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Then("\"New Workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("\"Source\" is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("\"Action\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("\"Inputs/Outputs\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I Select \"mysqlSource\" as Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.When("I select \"new_procedure\" as the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("\"Inputs/Outputs\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("I click \"Validate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the \"Test Connector and Calculate Outputs\" window is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.And("I click \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2214 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "value"});
            table2214.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2214.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2214.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2214.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2214.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2214.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2214.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2214.AddRow(new string[] {
                        "1212",
                        "ffff"});
#line 28
 testRunner.Then("Outputs appear as", ((string)(null)), table2214, "Then ");
#line 38
 testRunner.When("I click \"OK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2215 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2215.AddRow(new string[] {
                        "ID",
                        "[[new_procedure().id]]"});
            table2215.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 39
 testRunner.And("mappings are", ((string)(null)), table2215, "And ");
#line 43
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("the MySql Connector tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.And("the execution has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2216 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2216.AddRow(new string[] {
                        "[[new_procedure().id]] = 1212"});
            table2216.AddRow(new string[] {
                        "[[new_procedure().value]] = ffff"});
#line 46
 testRunner.Then("the debug output as", ((string)(null)), table2216, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Saved workflow with MySQL Connector tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void OpeningSavedWorkflowWithMySQLConnectorTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Saved workflow with MySQL Connector tool", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
   testRunner.Given("I open MySql_workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.Then("\"MySql_workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("\"Source\" equals \"mysqlSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("\"Action\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("\"Input/Output\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2217 = new TechTalk.SpecFlow.Table(new string[] {
                        "Inputs",
                        "Value",
                        "Empty is Null"});
#line 59
 testRunner.And("input mappings are", ((string)(null)), table2217, "And ");
#line 61
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("\"Mapping\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2218 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2218.AddRow(new string[] {
                        "id",
                        "[[new_procedure().id]]"});
            table2218.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 63
 testRunner.And("mappings are", ((string)(null)), table2218, "And ");
#line 67
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change Source on Existing tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void ChangeSourceOnExistingTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change Source on Existing tool", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
 testRunner.Given("I open MySql_workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
 testRunner.Then("\"MySql_workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("\"Source\" equals \"mysqlSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("\"Action\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("\"Input/Output\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2219 = new TechTalk.SpecFlow.Table(new string[] {
                        "Inputs",
                        "Value",
                        "Empty is Null"});
#line 77
 testRunner.And("input mappings are", ((string)(null)), table2219, "And ");
#line 79
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("\"Mapping\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2220 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2220.AddRow(new string[] {
                        "id",
                        "[[new_procedure().id]]"});
            table2220.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 81
 testRunner.And("mappings are", ((string)(null)), table2220, "And ");
#line 85
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("\"Source\" is changed from \"mysqlSource\" to \"TestMysql\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.And("\"Inputs/Outputs\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("\"Validate\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing MySql Connector and Test Execution is unsuccesful")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void EditingMySqlConnectorAndTestExecutionIsUnsuccesful()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing MySql Connector and Test Execution is unsuccesful", new string[] {
                        "ignore"});
#line 94
 this.ScenarioSetup(scenarioInfo);
#line 95
   testRunner.Given("I open \"MySql_workflow\" service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
   testRunner.And("\"MySql_workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
   testRunner.Then("\"1 Data Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
   testRunner.And("Data Source is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
   testRunner.When("\"DemoDB\" is selected as the data source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
   testRunner.Then("\"2 Select Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
   testRunner.And("\"dbo.InsertDummyUser\" is selected as the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
   testRunner.Then("\"3 Test Connector and Calculate Outputs\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
   testRunner.And("Inspect Data Connector hyper link is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2221 = new TechTalk.SpecFlow.Table(new string[] {
                        "fname",
                        "lname",
                        "username",
                        "password",
                        "lastAccessDate"});
            table2221.AddRow(new string[] {
                        "Change",
                        "Test",
                        "wolf",
                        "Dev",
                        "10/1/1990"});
#line 104
   testRunner.And("inputs are", ((string)(null)), table2221, "And ");
#line 107
   testRunner.And("\"Test\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
   testRunner.When("testing the action fails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
   testRunner.Then("\"4 Defaults and Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2222 = new TechTalk.SpecFlow.Table(new string[] {
                        "Inputs",
                        "Default Value",
                        "Required Field",
                        "Empty is Null"});
#line 111
   testRunner.And("input mappings are", ((string)(null)), table2222, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2223 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias",
                        "Recordset Name"});
#line 113
 testRunner.And("output mappings are", ((string)(null)), table2223, "And ");
#line 115
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing Actions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void ChangingActions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing Actions", ((string[])(null)));
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
 testRunner.Given("I open MySql_workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 120
 testRunner.Then("\"MySql_workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("\"Source\" equals \"mysqlSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And("\"Action\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("\"Input/Output\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2224 = new TechTalk.SpecFlow.Table(new string[] {
                        "Inputs",
                        "Value",
                        "Empty is Null"});
#line 126
 testRunner.And("\"Input/Output\" mappings are", ((string)(null)), table2224, "And ");
#line 128
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And("\"Mapping\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2225 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2225.AddRow(new string[] {
                        "id",
                        "[[new_procedure().id]]"});
            table2225.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 130
 testRunner.And("mappings are", ((string)(null)), table2225, "And ");
#line 134
 testRunner.When("\"Action\" is changed from \"new_procedure\" to \"getCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 135
 testRunner.Then("\"Inputs/Outputs\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2226 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
#line 138
 testRunner.And("\"Inputs/Outputs\" appear as", ((string)(null)), table2226, "And ");
#line 140
 testRunner.When("I click \"Validate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
 testRunner.Then("the \"Test Connector and Calculate Outputs\" window is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.And("I click \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2227 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "value"});
            table2227.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2227.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2227.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2227.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2227.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2227.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2227.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2227.AddRow(new string[] {
                        "1212",
                        "ffff"});
#line 143
 testRunner.Then("Outputs appear as", ((string)(null)), table2227, "Then ");
#line 153
 testRunner.When("I click \"OK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2228 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2228.AddRow(new string[] {
                        "ID",
                        "[[new_procedure().id]]"});
            table2228.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 154
 testRunner.And("mappings are", ((string)(null)), table2228, "And ");
#line 158
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change Recordset Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void ChangeRecordsetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change Recordset Name", ((string[])(null)));
#line 162
this.ScenarioSetup(scenarioInfo);
#line 163
 testRunner.Given("I open MySql_workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 164
 testRunner.Then("\"MySql_workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.And("\"Source\" equals \"mysqlSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.And("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.And("\"Action\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
 testRunner.And("\"Input/Output\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2229 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
#line 170
 testRunner.And("\"Inputs/Outputs\" appear as", ((string)(null)), table2229, "And ");
#line 172
 testRunner.When("I click \"Validate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
 testRunner.Then("the \"Test Connector and Calculate Outputs\" window is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
 testRunner.And("I click \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.When("I test the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2230 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "value"});
            table2230.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2230.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2230.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2230.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2230.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2230.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2230.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2230.AddRow(new string[] {
                        "1212",
                        "ffff"});
#line 177
 testRunner.And("Outputs appear as", ((string)(null)), table2230, "And ");
#line 187
 testRunner.When("I click \"OK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2231 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2231.AddRow(new string[] {
                        "ID",
                        "[[new_procedure().id]]"});
            table2231.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 188
 testRunner.And("mappings are", ((string)(null)), table2231, "And ");
#line 192
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.When("\"Recordset Name\" is changed from \"new_procedure\" to \"New_Category\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2232 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2232.AddRow(new string[] {
                        "id",
                        "[[New_Category().id]]"});
            table2232.AddRow(new string[] {
                        "value",
                        "[[New_Category().value]]"});
#line 194
 testRunner.Then("mappings are", ((string)(null)), table2232, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Invalid Recordset name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MySqlConnector")]
        public virtual void InvalidRecordsetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid Recordset name", ((string[])(null)));
#line 201
this.ScenarioSetup(scenarioInfo);
#line 202
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 203
 testRunner.Then("\"New Workflow\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
 testRunner.And("\"Source\" is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
 testRunner.And("\"Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.And("\"Action\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
 testRunner.And("\"Inputs/Outputs\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
 testRunner.When("I Select \"mysqlSource\" as Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 210
 testRunner.Then("\"Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 211
 testRunner.When("I select \"new_procedure\" as the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 212
 testRunner.Then("\"Inputs/Outputs\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 213
 testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2233 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
#line 214
 testRunner.And("\"Inputs/Outputs\" appear as", ((string)(null)), table2233, "And ");
#line 216
 testRunner.When("I click \"Validate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 217
 testRunner.Then("the \"Test Connector and Calculate Outputs\" window is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 218
 testRunner.And("I click \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
 testRunner.And("\"Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 220
 testRunner.When("I test the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2234 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "value"});
            table2234.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2234.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2234.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2234.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2234.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2234.AddRow(new string[] {
                        "1212",
                        "ffff"});
            table2234.AddRow(new string[] {
                        "123123123",
                        "aasdasdasdasd"});
            table2234.AddRow(new string[] {
                        "1212",
                        "ffff"});
#line 221
 testRunner.And("Outputs appear as", ((string)(null)), table2234, "And ");
#line 231
 testRunner.When("I click \"OK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2235 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2235.AddRow(new string[] {
                        "ID",
                        "[[new_procedure().id]]"});
            table2235.AddRow(new string[] {
                        "value",
                        "[[new_procedure().value]]"});
#line 232
 testRunner.And("mappings are", ((string)(null)), table2235, "And ");
#line 236
 testRunner.And("\"Recordset Name\" equals \"new_procedure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 237
 testRunner.When("\"Recordset Name\" is changed from \"new_procedure\" to \"#$New_Category\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 238
 testRunner.When("the MySql Connector tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 239
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2236 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2236.AddRow(new string[] {
                        "Error : input must be recordset or value"});
#line 240
 testRunner.Then("the debug output as", ((string)(null)), table2236, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
