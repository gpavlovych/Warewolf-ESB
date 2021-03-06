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
namespace Dev2.Activities.Specs.Apis
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ApisFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Apis.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Apis", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Apis")))
            {
                Dev2.Activities.Specs.Apis.ApisFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure all relevant information is displayed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Apis")]
        public virtual void EnsureAllRelevantInformationIsDisplayed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure all relevant information is displayed", new string[] {
                        "Apis",
                        "ignore"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I execute \"http://localhost:3142/apis.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("the response will be valid apis.json format", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "workflowDescription",
                        "Value"});
            table1.AddRow(new string[] {
                        "Name",
                        "RSAKLFLEROY"});
            table1.AddRow(new string[] {
                        "Description",
                        "\"\""});
            table1.AddRow(new string[] {
                        "Image",
                        "null"});
            table1.AddRow(new string[] {
                        "Url",
                        "http://RSAKLFLEROY:3142/apis.json"});
            table1.AddRow(new string[] {
                        "Tags",
                        "null"});
            table1.AddRow(new string[] {
                        "created",
                        "2015-07-22T00:00:00+02:00"});
            table1.AddRow(new string[] {
                        "Modified",
                        "2015-07-22T00:00:00+02:00"});
            table1.AddRow(new string[] {
                        "SpecificationVersion",
                        "0.15"});
#line 24
 testRunner.And("will have properties as", ((string)(null)), table1, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure all information is displayed per work flow for the Apis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureAllInformationIsDisplayedPerWorkFlowForTheApis()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure all information is displayed per work flow for the Apis", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I execute \"http://localhost:3142/apis.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("the response will be valid apis.json format", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "workflowDescription",
                        "propertyvalue"});
            table2.AddRow(new string[] {
                        "Name",
                        "InOut"});
            table2.AddRow(new string[] {
                        "Description",
                        "null"});
            table2.AddRow(new string[] {
                        "Image",
                        "null"});
            table2.AddRow(new string[] {
                        "humanUrl",
                        "null"});
            table2.AddRow(new string[] {
                        "baseUrl",
                        "\"http://RSAKLFLEROY:3142/secure/Acceptance Testing Resources/InOut.json\""});
            table2.AddRow(new string[] {
                        "version",
                        "null"});
            table2.AddRow(new string[] {
                        "Tags",
                        "null"});
            table2.AddRow(new string[] {
                        "properties",
                        "type = swagger; value = \"http://RSAKLFLEROY:3142/secure/Acceptance Testing Resour" +
                            "ces/InOut.api\""});
            table2.AddRow(new string[] {
                        "contact",
                        "null"});
#line 43
 testRunner.And("will have Apis properties as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure that the .json and .api url contain workflow permissions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureThatThe_JsonAnd_ApiUrlContainWorkflowPermissions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure that the .json and .api url contain workflow permissions", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given("I execute \"http://localhost:3142/apis.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("the response will be valid apis.json format", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("the work flow \"Hello World\" is \"visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Permissions"});
            table3.AddRow(new string[] {
                        "public"});
            table3.AddRow(new string[] {
                        "secure"});
#line 62
 testRunner.And("\"Hello World\" has the access permission as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "BaseUrl"});
            table4.AddRow(new string[] {
                        "\"http://RSAKLFLEROY:3142/secure/Hello World.json\""});
            table4.AddRow(new string[] {
                        "\"http://RSAKLFLEROY:3142/public/Hello World.json\""});
#line 66
 testRunner.Then("the permissions appear independantly in the baseUrl property as", ((string)(null)), table4, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Properties"});
            table5.AddRow(new string[] {
                        "\"http://RSAKLFLEROY:3142/secure/Hello World.api\""});
            table5.AddRow(new string[] {
                        "\"http://RSAKLFLEROY:3142/public/Hello World.api\""});
#line 70
 testRunner.And("the permissions appear independantly in the Properties value  as", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure the baseUrl permissions are valid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureTheBaseUrlPermissionsAreValid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure the baseUrl permissions are valid", ((string[])(null)));
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given("I execute \"http://rsaklfleroy:3142/public/Hello%20World.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And("public permissions are \"View,Execute,Contribute\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output"});
            table6.AddRow(new string[] {
                        "{\"rec\" : [{\"a\":\"name\"},{\"a\":\"dfsdfsdfsd\"}],\"Message\":\"Hello World.\"}"});
#line 80
 testRunner.Then("\"http://rsaklfleroy:3142/public/Hello%20World.json\" output appear as", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears(string execute, string permissions, string output, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure that if permissions are not granted that the relevant information appears", exampleTags);
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("I execute \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.And(string.Format("public permissions are \'{0}\'", permissions), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output"});
            table7.AddRow(new string[] {
                        ""});
#line 89
 testRunner.Then("\"http://rsaklfleroy:3142/public/Hello%20World.json\" output appear as", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure that if permissions are not granted that the relevant information appears")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Execute", "http://rsaklfleroy:3142/secure/Hello%20World.json")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:permissions", "View,Execute,Contribute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:output", "{\"rec\" : [{\"a\":\"name\"},{\"a\":\"dfsdfsdfsd\"}],\"Message\":\"Hello World.\"}")]
        public virtual void EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears_Variant0()
        {
            this.EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears("http://rsaklfleroy:3142/secure/Hello%20World.json", "View,Execute,Contribute", "{\"rec\" : [{\"a\":\"name\"},{\"a\":\"dfsdfsdfsd\"}],\"Message\":\"Hello World.\"}", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure that if permissions are not granted that the relevant information appears")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Execute", "http://rsaklfleroy:3142/public/Hello%20World.json")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:permissions", "View")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:output", "Access Denied for this request")]
        public virtual void EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears_Variant1()
        {
            this.EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears("http://rsaklfleroy:3142/public/Hello%20World.json", "View", "Access Denied for this request", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure that if permissions are not granted that the relevant information appears")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Execute", "http://rsaklfleroy:3142/public/Hello%20World.json")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:permissions", "Execute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:output", "{\"rec\" : [{\"a\":\"\",\"b\":\"\"}],}")]
        public virtual void EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears_Variant2()
        {
            this.EnsureThatIfPermissionsAreNotGrantedThatTheRelevantInformationAppears("http://rsaklfleroy:3142/public/Hello%20World.json", "Execute", "{\"rec\" : [{\"a\":\"\",\"b\":\"\"}],}", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Access will be denied if permissions changed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureAccessWillBeDeniedIfPermissionsChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure Access will be denied if permissions changed", ((string[])(null)));
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
 testRunner.Given("I have \"http://rsaklfleroy:3142/secure/Acceptance%20Tests/TestAssignWithRemote.js" +
                    "on\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
 testRunner.And("permissions are \"View,Execute,Contribute\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I execute \"http://rsaklfleroy:3142/public/Acceptance%20Tests/TestAssignWithRemote" +
                    ".json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output"});
            table8.AddRow(new string[] {
                        "Access has been denied for this request."});
#line 104
 testRunner.Then("\"http://rsaklfleroy:3142/public/Acceptance%20Tests/TestAssignWithRemote.json\" pro" +
                    "perties appear as", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure all relevant information is displayed based on access type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureAllRelevantInformationIsDisplayedBasedOnAccessType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure all relevant information is displayed based on access type", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I execute \"http://server:3142/public/apis.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("only publically available services should be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure swagger returns correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void EnsureSwaggerReturnsCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure swagger returns correctly", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line 116
 testRunner.Given("I execute \"http://rsaklfleroy:3142/public/Hello%20World.api\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 117
 testRunner.And("public permissions are \"View,Execute,Contribute\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
 testRunner.Then("\"Https\" is not visible in Swagger definition", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display formals based on http or https")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void DisplayFormalsBasedOnHttpOrHttps()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display formals based on http or https", ((string[])(null)));
#line 122
this.ScenarioSetup(scenarioInfo);
#line 123
 testRunner.Given("I execute \"http://rsaklfleroy:3142/public/Hello%20World.api\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 124
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
 testRunner.Then("the swagger definition should contain \"produces\" with the values \"[\"application/j" +
                    "son\",\"application/xml\"]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display full path on service name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Apis")]
        public virtual void DisplayFullPathOnServiceName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display full path on service name", ((string[])(null)));
#line 128
this.ScenarioSetup(scenarioInfo);
#line 129
 testRunner.Given("I execute \"http://rsaklfleroy:3142/public/Hello%20World.api\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 130
 testRunner.When("the request returns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
 testRunner.Then("the swagger definition should contain \"paths\" with the values \"{\'serviceName\':\'Pu" +
                    "blic/Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
