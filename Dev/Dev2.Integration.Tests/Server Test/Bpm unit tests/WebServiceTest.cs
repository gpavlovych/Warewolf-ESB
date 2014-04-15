﻿using System;
using Dev2.Integration.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Integration.Tests.Dev2.Application.Server.Tests.Bpm_unit_tests
{
    /// <summary>
    /// Summary description for WebServiceTest
    /// </summary>
    [TestClass]
    public class WebServiceTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("WebService_Invoke")]
        public void WebService_Invoke_IntegrationTest_ExpectPass()
        {

            //------------Setup for test--------------------------
            string postData = String.Format("{0}{1}", ServerSettings.WebserverURI, "WebServiceTest");

            const string expected = @"<result>PASS</result>";

            //------------Execute Test---------------------------
            string ResponseData = TestHelper.PostDataToWebserver(postData);

            ////------------Assert Results-------------------------
            StringAssert.Contains(ResponseData, expected, " **** I expected { " + expected + " } but got { " + ResponseData + " }");
        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WebService_Invoke_IncorrectInput")]
        public void WebService_Invoke_IntegrationTest_ExpectCorrectErrorsForBadInputs()
        {
            var id = Guid.NewGuid();
            //------------Setup for test--------------------------
            string postData = String.Format("{0}{1}", ServerSettings.WebserverURI, "11365_WebService");

            const string expected = @"<DataList><d>&lt;InnerError&gt;The &apos;[&apos; character, hexadecimal value 0x5B, cannot be included in a name. Line 5, position 4.&lt;/InnerError&gt;&lt;InnerError&gt;Recordset index (**) contains invalid character(s)&lt;/InnerError&gt;&lt;InnerError&gt;Data Format Error : It is likely that you tested with one format yet the service is returning another. IE you tested with XML and it now returns JSON&lt;/InnerError&gt;</d></DataList>";

            //------------Execute Test---------------------------
            string ResponseData = TestHelper.PostDataToWebserverAsRemoteAgent(postData, id);
            var debugItems = TestHelper.FetchRemoteDebugItems(ServerSettings.WebserverURI, id);
            ////------------Assert Results-------------------------
            StringAssert.Contains(ResponseData, expected, " **** I expected { " + expected + " } but got { " + ResponseData + " }");
            Assert.AreEqual(debugItems.Count,2);
            Assert.AreEqual(debugItems[0].ErrorMessage.Trim(),  @"1 The '[' character, hexadecimal value 0x5B, cannot be included in a name. Line 5, position 4.
 2 Recordset index (**) contains invalid character(s)
 3 Data Format Error : It is likely that you tested with one format yet the service is returning another. IE you tested with XML and it now returns JSON");
        }
    }
}
