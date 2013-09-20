﻿using System;
using System.IO;
using Dev2.Providers.Logs;
using Dev2.Studio;
using Dev2.Studio.Core.Helpers;
using Dev2.Studio.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Core.Tests.Diagnostics
{
    [TestClass]
    public class FileHelperTests
    {
        private static string NewPath;
        private static string OldPath;
        static TestContext Context;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Context = testContext;
            NewPath = Context.TestDir + @"\Warewolf\";
            OldPath = Context.TestDir + @"\Dev2\";
        }

        #region Migrate Temp Data

        [TestMethod]
        public void MigrateOldTempDataExpectedAllFilesCopied()
        {
            //Initialization
            if (!Directory.Exists(OldPath))
            {
                Directory.CreateDirectory(OldPath);
            }
            if (!File.Exists(OldPath + "\\a file in the old temp dir"))
            {
                var stream = File.Create(OldPath + "\\a file in the old temp dir");
                stream.Close();
            }
            if (!Directory.Exists(OldPath + "\\temp"))
            {
                Directory.CreateDirectory(OldPath + "\\temp");
            }
            if (!File.Exists(OldPath + "\\temp\\a file in asub dir in the old temp folder"))
            {
                var stream = File.Create(OldPath + "\\temp\\a file in a sub dir in the old temp folder");
                stream.Close();
            }

            //Execute
            FileHelper.MigrateTempData(Context.TestDir);

            //Assert
            Assert.IsTrue(File.Exists(NewPath + "\\a file in the old temp dir"), "File not migrated from old temp folder");
            Assert.IsTrue(File.Exists(NewPath + "\\temp\\a file in a sub dir in the old temp folder"), "File in a sub directory of the old temp folder not migrated to new temp folder");
        }
        
        #endregion

        #region Create Directory from String

        [TestMethod]
        [TestCategory("StringExtensionUnitTest")]
        [Description("Test for FileHelper's CreateDirectoryFromString method: A valid file directory is passed to it and that files directory is created")]
        [Owner("Ashley Lewis")]
        // ReSharper disable InconsistentNaming
        public void FileHelper_FileHelperUnitTest_CreateDirectoryFromString_DirectoryCreated()
        // ReSharper restore InconsistentNaming
        {
            //init
            var fileDir = Context.TestDir + "\\Sub Directory\\some file name.ext";

            //exe
            FileHelper.CreateDirectoryFromString(fileDir);

            //assert
            Assert.IsTrue(Directory.Exists(Context.TestDir + "\\Sub Directory"));
        }

        #endregion

        #region Get ServerLog TempPath

        [TestMethod]
        [Owner("Ashley Lewis")]
        [TestCategory("FileHelper_GetServerLogTempPath")]
        public void FileHelper_GetServerLogTempPath_ServerLogFileBlank_DoNotCreateTempFile()
        {
            var mockConnection = new Mock<IEnvironmentConnection>();
            mockConnection.Setup(conn => conn.ExecuteCommand(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(string.Empty);
            var mockServer = new Mock<IEnvironmentModel>();
            mockServer.Setup(svr => svr.Connection).Returns(mockConnection.Object);

            //------------Execute Test---------------------------
            var actual = FileHelper.GetServerLogTempPath(mockServer.Object);

            // Assert DoNotCreateTempFile
            Assert.IsNull(actual, "Path returned for blank log file");
        }

        #endregion

        [TestMethod]
        public void TEST()
        {
            Logger.TraceInfo();
        }
    }
}
