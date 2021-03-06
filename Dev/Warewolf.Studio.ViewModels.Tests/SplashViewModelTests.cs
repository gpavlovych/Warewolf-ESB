﻿using System;
using System.Collections.Generic;

using Dev2.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Warewolf.Studio.ViewModels.Tests
{
    [TestClass]
    public class SplashViewModelTests
    {
        #region Fields

        private Mock<IServer> _serverMock;
        private Mock<IExternalProcessExecutor> _externalProcessExecutorMock;

        private List<string> _changedProperties;
        private SplashViewModel _target;

        #endregion Fields

        #region Test initialize

        [TestInitialize]
        public void TestInitialize()
        {
            _serverMock = new Mock<IServer>();
            _externalProcessExecutorMock = new Mock<IExternalProcessExecutor>();

            _changedProperties = new List<string>();
            _target = new SplashViewModel(_serverMock.Object, _externalProcessExecutorMock.Object);
            _target.PropertyChanged += (sender, args) => { _changedProperties.Add(args.PropertyName); };
        }

        #endregion Test initialize

        #region Test construction

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSplashViewModelServerNull()
        {
            //act
            new SplashViewModel(null, _externalProcessExecutorMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSplashViewModelExternalProcessExecutorNull()
        {
            //act
            new SplashViewModel(_serverMock.Object, null);
        }

        #endregion Test construction

        #region Test commands

        [TestMethod]
        public void TestContributorsCommandCanExecute()
        {
            //act
            var result = _target.ContributorsCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestContributorsCommandExecute()
        {
            //act
            _target.ContributorsCommand.Execute(null);

            //assert
            _externalProcessExecutorMock.Verify(it=>it.OpenInBrowser(_target.ContributorsUrl));
        }

        [TestMethod]
        public void TestCommunityCommandCanExecute()
        {
            //act
            var result = _target.CommunityCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCommunityCommandExecute()
        {
            //act
            _target.CommunityCommand.Execute(null);

            //assert
            _externalProcessExecutorMock.Verify(it => it.OpenInBrowser(_target.CommunityUrl));
        }

        [TestMethod]
        public void TestExpertHelpCommandCanExecute()
        {
            //act
            var result = _target.ExpertHelpCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExpertHelpCommandExecute()
        {
            //act
            _target.ExpertHelpCommand.Execute(null);

            //assert
            _externalProcessExecutorMock.Verify(it => it.OpenInBrowser(_target.ExpertHelpUrl));
        }

        [TestMethod]
        public void TestDevUrlCommandCanExecute()
        {
            //act
            var result = _target.DevUrlCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDevUrlCommandExecute()
        {
            //act
            _target.DevUrlCommand.Execute(null);

            //assert
            _externalProcessExecutorMock.Verify(it => it.OpenInBrowser(_target.DevUrl));
        }

        [TestMethod]
        public void TestWarewolfUrlCommandCanExecute()
        {
            //act
            var result = _target.WarewolfUrlCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestWarewolfUrlCommandExecute()
        {
            //act
            _target.WarewolfUrlCommand.Execute(null);

            //assert
            _externalProcessExecutorMock.Verify(it => it.OpenInBrowser(_target.WarewolfUrl));
        }

        #endregion Test commands

        #region Test properties

        [TestMethod]
        public void TestDevUrl()
        {
            //arrange
            var expectedValue = new Uri("http://localhost/");

            //act
            _target.DevUrl = expectedValue;
            var value = _target.DevUrl;

            //assert
            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestWarewolfUrl()
        {
            //arrange
            var expectedValue = new Uri("http://localhost/");

            //act
            _target.WarewolfUrl = expectedValue;
            var value = _target.WarewolfUrl;

            //assert
            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestContributorsUrl()
        {
            //arrange
            var expectedValue = new Uri("http://localhost/");

            //act
            _target.ContributorsUrl = expectedValue;
            var value = _target.ContributorsUrl;

            //assert
            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestCommunityUrl()
        {
            //arrange
            var expectedValue = new Uri("http://localhost/");

            //act
            _target.CommunityUrl = expectedValue;
            var value = _target.CommunityUrl;

            //assert
            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestExpertHelpUrl()
        {
            //arrange
            var expectedValue = new Uri("http://localhost/");

            //act
            _target.ExpertHelpUrl = expectedValue;
            var value = _target.ExpertHelpUrl;

            //assert
            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestServer()
        {
            //arrange
            var expectedValueMock = new Mock<IServer>();

            //act
            _target.Server = expectedValueMock.Object;
            var value = _target.Server;

            //assert
            Assert.AreSame(expectedValueMock.Object, value);
        }

        [TestMethod]
        public void TestExternalProcessExecutor()
        {
            //arrange
            var expectedValueMock = new Mock<IExternalProcessExecutor>();

            //act
            _target.ExternalProcessExecutor = expectedValueMock.Object;
            var value = _target.ExternalProcessExecutor;

            //assert
            Assert.AreSame(expectedValueMock.Object, value);
        }

        [TestMethod]
        public void TestServerVersion()
        {
            //arrange
            var expectedValue = "someResourceName";
            _changedProperties.Clear();

            //act
            _target.ServerVersion = expectedValue;
            var value = _target.ServerVersion;

            //asert
            Assert.AreEqual(expectedValue, value);
            Assert.IsTrue(_changedProperties.Contains("ServerVersion"));
        }

        [TestMethod]
        public void TestServerInformationalVersion()
        {
            //arrange
            var expectedValue = "someResourceName";
            _changedProperties.Clear();

            //act
            _target.ServerInformationalVersion = expectedValue;
            var value = _target.ServerInformationalVersion;

            //asert
            Assert.AreEqual(expectedValue, value);
            Assert.IsTrue(_changedProperties.Contains("ServerInformationalVersion"));
        }

        [TestMethod]
        public void TestStudioVersion()
        {
            //arrange
            var expectedValue = "someResourceName";
            _changedProperties.Clear();

            //act
            _target.StudioVersion = expectedValue;
            var value = _target.StudioVersion;

            //asert
            Assert.AreEqual(expectedValue, value);
            Assert.IsTrue(_changedProperties.Contains("StudioVersion"));
        }

        [TestMethod]
        public void TestStudioInformationalVersion()
        {
            //arrange
            var expectedValue = "someResourceName";
            _changedProperties.Clear();

            //act
            _target.StudioInformationalVersion = expectedValue;
            var value = _target.StudioInformationalVersion;

            //asert
            Assert.AreEqual(expectedValue, value);
            Assert.IsTrue(_changedProperties.Contains("StudioInformationalVersion"));
        }

        #endregion Test properties

        #region Test methods

        [TestMethod]
        public void TestShowServerVersionYesterday()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed yesterday as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddDays(-1)));
            
            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersion2DaysAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed 2 days ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddDays(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }
  
        [TestMethod]
        public void TestShowServerVersionMinuteAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed one minute ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddMinutes(-1)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersion2MinutesAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed 2 minutes ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddMinutes(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersionHourAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed an hour ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddHours(-1)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersion2HoursAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed 2 hours ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddHours(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersionMonthAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed one month ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddMonths(-1).AddDays(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersion2MonthsAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed 2 months ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddMonths(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersionYearAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed one year ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddYears(-1)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersion2YearsAgo()
        {
            //arrange
            var expectedServerVersion = "Version 4.0.3 build 2";
            var expectedServerInformationalVersion = "committed 2 years ago as SomeVeryLo...";
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3.2");
            _serverMock.Setup(it => it.GetServerInformationalVersion())
                .Returns(string.Format("{0:MM/dd/yyyy hh:mm} SomeVeryLongLongExample", DateTime.Now.AddYears(-2)));

            //act
            _target.ShowServerVersion();

            //assert
            Assert.AreEqual(expectedServerVersion, _target.ServerVersion);
            Assert.AreEqual(expectedServerInformationalVersion, _target.ServerInformationalVersion);
        }

        [TestMethod]
        public void TestShowServerVersionInvalidVersion()
        {
            //arrange
            _serverMock.Setup(it => it.GetServerVersion()).Returns("4.0.3");
            _serverMock.Setup(it => it.GetServerInformationalVersion()).Returns("SomeVeryLongLongExample");

            //act
            _target.ShowServerVersion();

            //assert
            Assert.IsTrue(string.IsNullOrEmpty(_target.ServerVersion));
            Assert.IsTrue(string.IsNullOrEmpty(_target.ServerInformationalVersion));
        }

        #endregion Test methods
    }
}