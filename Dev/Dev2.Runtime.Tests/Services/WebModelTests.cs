﻿using System;
using Dev2.Common;
using Dev2.Data.SystemTemplates.Models;
using Dev2.DataList.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dev2.Runtime.Services;
using Dev2.Runtime.Services.Data;
using System.Collections.Generic;
using Dev2.Data.SystemTemplates;

namespace Dev2.Tests.Runtime.Dev2.Runtime.Services.Tests
{

    // Sashen : 31-01-2012 : Testing Feedback
    // Tests Missing an Author comment
    // Missing Tests:
    // Fetching a Decision Model with a Null DataList (Guid.Empty) - Fixed
    // Fetching a Switch Decision Model - all tests - Fixed
    // Fetching a switch case decision model tests - Un-used have commented it out
    // No test cases for SaveModel - Fixed

    [TestClass]
    public class WebModelTests
    {
        [TestMethod]
        public void FetchDecisionModel_Expected_WebModel()
        {
            var testWebModel = new WebModel();

            IDev2DataModel testModel = new Dev2Decision();

            var stack = new Dev2DecisionStack { TheStack = new List<Dev2Decision> { new Dev2Decision() } };

            string expected = stack.ToWebModel();
            string actual = testWebModel.FetchDecisionModel("", Guid.Empty, generateGuid());

            Assert.AreEqual(expected, actual);
        
        }



        [TestMethod]
        public void FetchDecisionModel_Expected_EmptyJsonString()
        {
            var testWebModel = new WebModel();

            IDev2DataModel testModel = new Dev2Decision();

            var stack = new Dev2DecisionStack { TheStack = new List<Dev2Decision> { new Dev2Decision() } };

            string expected = "{}";
            string actual = testWebModel.FetchDecisionModel("", Guid.Empty, Guid.Empty);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FetchSwitchModel_Expected_WebModel()
        {
            var testWebModel = new WebModel();
            string expected = DataListConstants.DefaultSwitch.ToWebModel();

            string actual = testWebModel.FetchSwitchExpression(expected, Guid.Empty, generateGuidSwitch());

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FetchSwitchModel_Expected_EmptyJson()
        {
            var testWebModel = new WebModel();
            string expected = DataListConstants.DefaultSwitch.ToWebModel();

            string actual = testWebModel.FetchSwitchExpression(expected, Guid.Empty, Guid.Empty);

            Assert.AreEqual("{}", actual);

        }

        [TestMethod]
        public void SaveModelData_Expected_SavedMessage()
        {
            var testWebModel = new WebModel();

            string actual = testWebModel.SaveModel("Dummy Model Data", Guid.Empty, generateGuidSwitch());

            string expected = "{  \"message\" : \"Saved Model\"} ";

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void SaveModelData_Null_DataListID_Expected_ErrorMessage()
        {
            var testWebModel = new WebModel();

            string actual = testWebModel.SaveModel("Dummy Model Data", Guid.Empty, Guid.Empty);

            string expected = "{ \"message\" : \"Error Saving Model\"} ";

            Assert.AreEqual(expected, actual);

        }


        #region private method region

        private Guid generateGuid()
        {
            IDataListCompiler testCompiler = DataListFactory.CreateDataListCompiler();

            var stack = new Dev2DecisionStack();
            stack.TheStack = new List<Dev2Decision> { new Dev2Decision() };

            var error = new ErrorResultTO();
            Guid MyModel = testCompiler.PushSystemModelToDataList(stack, out error);

            return MyModel;
        }


        private Guid generateGuidSwitch()
        {
            IDataListCompiler testCompiler = DataListFactory.CreateDataListCompiler();

            var stack = new Dev2Switch() { SwitchVariable = "[[Dummy]]" };
            
            var error = new ErrorResultTO();
            Guid MyModel = testCompiler.PushSystemModelToDataList(stack, out error);

            return MyModel;
        }

        #endregion
    }
}
