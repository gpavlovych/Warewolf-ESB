﻿using System;
using System.Collections.ObjectModel;
using Dev2.Activities.Designers2.Core.ActionRegion;
using Dev2.Activities.Designers2.Core.CloneInputRegion;
using Dev2.Activities.Designers2.Core.InputRegion;
using Dev2.Activities.Designers2.Core.Source;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.ServerProxyLayer;
using Dev2.Studio.Core.Activities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// ReSharper disable InconsistentNaming

namespace Dev2.Activities.Designers.Tests.Core.Database
{
    [TestClass]
    public class DatabaseInputRegionTest
    {
        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_Constructor")]
        public void DatabaseInputRegion_Constructor_Scenerio_Result()
        {
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };

            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);
            Assert.AreEqual(region.IsEnabled, false);
            Assert.AreEqual(region.Errors.Count, 0);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_Constructor")]
        public void DatabaseInputRegion_Constructor_TestInput_ConstructorEmpty()
        {
            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());

            var region = new DatabaseInputRegion();
            Assert.AreEqual(region.IsEnabled, false);
        }


        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_TestClone")]
        public void DatabaseInputRegion_TestClone()
        {
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };
            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);
            Assert.AreEqual(region.IsEnabled, false);
            Assert.AreEqual(region.Errors.Count, 0);
            var clone = region.CloneRegion() as DatabaseInputRegion;
            if (clone != null)
            {
                Assert.AreEqual(clone.IsEnabled, false);
                Assert.AreEqual(clone.Errors.Count, 0);
            }
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_Test")]
        public void DatabaseInputRegion_Test_InputAddHeader_ExpectHeightChanges()
        {
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };
            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);
            Assert.AreEqual(region.IsEnabled, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_Test")]
        public void DatabaseInputRegion_Test_InputAddHeader_ExpectHeightChangesPastThree()
        {
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };
            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);
            Assert.AreEqual(region.IsEnabled, false);
        }


        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_RestoreFromPrevious")]
        public void DatabaseInputRegion_RestoreFromPrevious_Restore_ExpectValuesChanged()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };
            var src = new Mock<IDbServiceModel>();
            src.Setup(a => a.RetrieveSources()).Returns(new ObservableCollection<IDbSource>());
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);
            // ReSharper disable once UseObjectOrCollectionInitializer
            var regionToRestore = new DatabaseInputRegionClone();
            regionToRestore.IsEnabled = true;
            //------------Execute Test---------------------------
            region.RestoreRegion(regionToRestore);
            //------------Assert Results-------------------------

        }


        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DatabaseInputRegion_SourceChanged")]
        public void DatabaseInputRegion_SourceChanged_UpdateValues()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfSqlServerDatabaseActivity() { SourceId = id };
            var src = new Mock<IDbServiceModel>();
            var lst = new ObservableCollection<IDbSource>() { new DbSourceDefinition() { Name = "bravo" }, new DbSourceDefinition() { Name = "johnny" } };
            src.Setup(a => a.RetrieveSources()).Returns(lst);
            DatabaseSourceRegion sourceRegion = new DatabaseSourceRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), enSourceType.SqlDatabase);
            DbActionRegion dbActionRegion = new DbActionRegion(src.Object, ModelItemUtils.CreateModelItem(new DsfSqlServerDatabaseActivity()), sourceRegion);

            var region = new DatabaseInputRegion(ModelItemUtils.CreateModelItem(act), dbActionRegion);

            sourceRegion.SelectedSource = lst[0];
            Assert.AreEqual(region.Inputs.Count, 0);
        }
    }
}
