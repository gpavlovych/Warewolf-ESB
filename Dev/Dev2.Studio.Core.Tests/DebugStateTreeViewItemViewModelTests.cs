﻿using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Dev2.Composition;
using Dev2.Diagnostics;
using Dev2.Services.Events;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.ViewModels.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Core.Tests
{
    [TestClass]
    public class DebugStateTreeViewItemViewModelTests
    {
        static ImportServiceContext _importContext;

        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            _importContext = CompositionInitializer.DefaultInitialize();
        }

        // BUG 8373: TWR
        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_Constructor_IsExpanded_False()
        {
            //Setup
            var serverID = Guid.NewGuid();
            const string ServerName = "Myserver";

            var env = new Mock<IEnvironmentModel>();
            env.Setup(e => e.ID).Returns(serverID);
            env.Setup(e => e.Name).Returns(ServerName);

            var env2 = new Mock<IEnvironmentModel>();
            env2.Setup(e => e.ID).Returns(Guid.NewGuid());

            var envRep = new Mock<IEnvironmentRepository>();
            envRep.Setup(e => e.All()).Returns(() => new[] { env.Object, env2.Object });

            var content = new DebugState { ServerID = serverID };

            //Execute
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };

            //Assert
            Assert.IsFalse(vm.IsExpanded, "The debug state tree viewmodel should be collapsed if not explicitly expanded in constructor");
        }

        // BUG 8373: TWR
        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_Constructor_EnvironmentRepository_SetsDebugStateServer()
        {
            var environmentID = Guid.NewGuid();
            const string ServerName = "Myserver";

            var env = new Mock<IEnvironmentModel>();
            env.Setup(e => e.ID).Returns(environmentID);
            env.Setup(e => e.Name).Returns(ServerName);

            var env2 = new Mock<IEnvironmentModel>();
            env2.Setup(e => e.ID).Returns(Guid.NewGuid());

            var envRep = new Mock<IEnvironmentRepository>();
            envRep.Setup(e => e.All()).Returns(() => new[] { env.Object, env2.Object });

            var content = new DebugState { EnvironmentID = environmentID };
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };
            Assert.AreEqual(ServerName, content.Server);
        }

        // BUG 8373: TWR
        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_Constructor_CanDetectRemoteServerName()
        {
            var serverID = Guid.NewGuid();
            const string ServerName = "Myserver";

            var env = new Mock<IEnvironmentModel>();
            env.Setup(e => e.ID).Returns(serverID);
            env.Setup(e => e.Name).Returns(ServerName);


            var env2ID = Guid.NewGuid();

            var env2 = new Mock<IEnvironmentModel>();
            env2.Setup(e => e.ID).Returns(env2ID);
            env2.Setup(e => e.Name).Returns("Unknown Remote Server");

            var envRep = new Mock<IEnvironmentRepository>();
            envRep.Setup(e => e.All()).Returns(() => new[] { env.Object, env2.Object });

            var content = new DebugState { ServerID = serverID, Server = env2ID.ToString() };
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };
            Assert.AreEqual("Unknown Remote Server", vm.Content.Server);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_NullContent_NoExceptionThrown()
        {
            //------------Setup for test--------------------------
            var envRep = new Mock<IEnvironmentRepository>();
            envRep.Setup(r => r.All()).Returns(new List<IEnvironmentModel>());

            //------------Execute Test---------------------------
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object);

            //------------Assert Results-------------------------
            Assert.AreEqual(0, vm.Inputs.Count);
            Assert.AreEqual(0, vm.Outputs.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DebugStateTreeViewItemViewModel_Constructor_NullEnvironmentRepository_ExceptionThrown()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            var vm = new DebugStateTreeViewItemViewModelMock(null);

            //------------Assert Results-------------------------
            Assert.AreEqual(0, vm.Inputs.Count);
            Assert.AreEqual(0, vm.Outputs.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_ContentIsMiddleStep_AssignsNameToContentServer()
        {
            Verify_Constructor_AssignsNameToContentServer(StateType.Append);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_ContentIsFirstStep_AssignsNameToContentServer()
        {
            Verify_Constructor_AssignsNameToContentServer(StateType.Start);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_ContentIsLastStep_AssignsNameToContentServer()
        {
            Verify_Constructor_AssignsNameToContentServer(StateType.End);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_ContentServerIsRemote_AssignsUnknownNameToContentServer()
        {
            Verify_Constructor_AssignsNameToContentServer(StateType.Append, contentServerIsSource: true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        public void DebugStateTreeViewItemViewModel_Constructor_ContentWithItems_BindsInputsAndOutputs()
        {
            //------------Setup for test--------------------------
            var envRep = CreateEnvironmentRepository();

            var expected = new DebugState { DisplayName = "IsSelectedTest", ID = Guid.NewGuid(), ActivityType = ActivityType.Step };
            expected.Inputs.Add(new DebugItem(new[] { new DebugItemResult(), new DebugItemResult { GroupName = "group1", GroupIndex = 1 } }));
            expected.Outputs.Add(new DebugItem(new[] { new DebugItemResult(), new DebugItemResult { GroupName = "group1", GroupIndex = 1 } }));

            //------------Execute Test---------------------------
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = expected };

            //------------Assert Results-------------------------
            Assert.AreEqual(1, vm.Inputs.Count);
            Assert.AreEqual(1, vm.Outputs.Count);
        }


        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_Constructor_ActivityTypeIsNotWorkflow_PublishesSelectionEventWithActivitySelectionTypeAdd()
        {
            Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType.Step, expectedSelectionType: ActivitySelectionType.Add, expectedCount: 1);
        }

        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_Constructor")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_Constructor_ActivityTypeIsWorkflow_DoesNotPublishSelectionEventWithActivitySelectionTypeAdd()
        {
            Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType.Workflow, expectedSelectionType: ActivitySelectionType.Add, expectedCount: 0);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_AppendError")]
        public void DebugStateTreeViewItemViewModel_AppendError_ContentHasError_AppendsErrorToContentError()
        {
            Verify_AppendError(contentHasError: true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("DebugStateTreeViewItemViewModel_AppendError")]
        public void DebugStateTreeViewItemViewModel_AppendError_ContentHasNoError_AppendsErrorToContentError()
        {
            Verify_AppendError(contentHasError: false);
        }

        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_IsSelected")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_IsSelected_SetsSelectionTypeToSingle()
        {
            //------------Setup for test--------------------------
            var content = new DebugState { DisplayName = "Error Test", ID = Guid.NewGuid(), ActivityType = ActivityType.Workflow };

            var envRep = CreateEnvironmentRepository();
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };

            //------------Execute Test---------------------------
            vm.SelectionType = ActivitySelectionType.Add;
            vm.IsSelected = true;

            //------------Assert Results-------------------------
            Assert.AreEqual(ActivitySelectionType.Single, vm.SelectionType);
        }

        [TestMethod]
        [TestCategory("DebugStateTreeViewItemViewModel_IsSelected")]
        [Owner("Trevor Williams-Ros")]
        public void DebugStateTreeViewItemViewModel_IsSelected_PublishesSelectionEventWithSameActivitySelectionType()
        {
            Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType.Service, expectedSelectionType: ActivitySelectionType.None, expectedCount: 1, setIsSelected: true);
            Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType.Service, expectedSelectionType: ActivitySelectionType.Single, expectedCount: 1, setIsSelected: true);
            Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType.Service, expectedSelectionType: ActivitySelectionType.Add, expectedCount: 1, setIsSelected: true);
        }

        static void Verify_IsSelected_PublishesDebugSelectionChangedEventArgs(ActivityType activityType, ActivitySelectionType expectedSelectionType, int expectedCount, bool setIsSelected = false)
        {
            var expected = new DebugState { DisplayName = "IsSelectedTest", ID = Guid.NewGuid(), ActivityType = activityType };

            var events = new List<DebugSelectionChangedEventArgs>();

            var selectionChangedEvents = EventPublishers.Studio.GetEvent<DebugSelectionChangedEventArgs>();
            selectionChangedEvents.Subscribe(events.Add);

            var envRep = CreateEnvironmentRepository();

            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = expected };

            if(setIsSelected)
            {
                // clear constructor events
                events.Clear();

                // events are only triggered when property changes to true
                vm.IsSelected = false;

                vm.SelectionType = expectedSelectionType;
                vm.IsSelected = true;
            }

            EventPublishers.Studio.RemoveEvent<DebugSelectionChangedEventArgs>();

            Assert.AreEqual(expectedCount, events.Count);
            for(var i = 0; i < expectedCount; i++)
            {
                Assert.AreEqual(expectedSelectionType, events[i].SelectionType);
                Assert.AreSame(expected, events[i].DebugState);
            }
        }

        static void Verify_Constructor_AssignsNameToContentServer(StateType stateType, bool contentServerIsSource = false)
        {
            //------------Setup for test--------------------------
            var environmentID = Guid.NewGuid();
            var serverName = "TestEnvironment";

            var env = new Mock<IEnvironmentModel>();
            env.Setup(e => e.ID).Returns(environmentID);
            env.Setup(e => e.Name).Returns(serverName);

            var envRep = CreateEnvironmentRepository(env.Object);

            var content = new DebugState { Server = (!contentServerIsSource ? Guid.Empty : Guid.NewGuid()).ToString(), EnvironmentID = environmentID, StateType = stateType, DisplayName = "IsSelectedTest", ID = Guid.NewGuid(), ActivityType = ActivityType.Workflow };
            content.OriginalInstanceID = content.ID;


            //------------Execute Test---------------------------
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };

            //------------Assert Results-------------------------
            Assert.AreEqual(serverName, content.Server);
        }

        static void Verify_AppendError(bool contentHasError)
        {
            //------------Setup for test--------------------------
            const string AppendError = "Appended text";
            const string ContentError = "Content text";

            var content = new DebugState { DisplayName = "Error Test", ID = Guid.NewGuid(), ActivityType = ActivityType.Workflow };

            var expectedProps = new[] { "Content.ErrorMessage", "Content.HasError", "Content", "HasError" };
            var actualProps = new List<string>();

            var envRep = CreateEnvironmentRepository();
            var vm = new DebugStateTreeViewItemViewModelMock(envRep.Object) { Content = content };
            vm.PropertyChanged += (sender, args) => actualProps.Add(args.PropertyName);

            //------------Execute Test---------------------------
            vm.Content.HasError = contentHasError;
            vm.Content.ErrorMessage = ContentError;
            vm.AppendError(AppendError);

            //------------Assert Results-------------------------
            if(contentHasError)
            {
                Assert.AreEqual(ContentError + AppendError, content.ErrorMessage);
            }
            else
            {
                Assert.AreEqual(AppendError, content.ErrorMessage);
            }
            Assert.IsTrue(content.HasError);
            Assert.IsTrue(vm.HasError.Value);

            CollectionAssert.AreEqual(expectedProps, actualProps);
        }

        static Mock<IEnvironmentRepository> CreateEnvironmentRepository(params IEnvironmentModel[] environments)
        {
            var source = new Mock<IEnvironmentModel>();
            source.Setup(e => e.ID).Returns(Guid.Empty);
            source.Setup(e => e.Name).Returns("localhost");

            var envRep = new Mock<IEnvironmentRepository>();
            envRep.Setup(r => r.All()).Returns(environments ?? new IEnvironmentModel[0]);
            envRep.Setup(r => r.Source).Returns(source.Object);
            return envRep;
        }
    }

    public class DebugStateTreeViewItemViewModelMock : DebugStateTreeViewItemViewModel
    {
        public DebugStateTreeViewItemViewModelMock(IEnvironmentRepository environmentRepository)
            : base(environmentRepository)
        {
        }
    }
}
