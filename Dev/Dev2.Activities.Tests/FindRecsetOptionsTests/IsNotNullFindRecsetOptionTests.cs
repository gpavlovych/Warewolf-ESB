using System.Collections.Generic;
using Dev2.DataList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace Dev2.Tests.Activities.FindRecsetOptionsTests
{
    [TestClass]
    public class IsNotNullFindRecsetOptionTests
    {
        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("RsOpIsNotNull_CreateFunc")]
        public void RsOpIsNotNull_CreateFunc_WhenNull_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var rsOpIsNull = new RsOpIsNotNull();
            
            //------------Execute Test---------------------------
            var func = rsOpIsNull.CreateFunc(new List<DataASTMutable.WarewolfAtom>{DataASTMutable.WarewolfAtom.Nothing}, null,null, false);
            var isNull = func.Invoke(DataASTMutable.WarewolfAtom.Nothing);
            //------------Assert Results-------------------------
            Assert.IsFalse(isNull);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("RsOpIsNotNull_CreateFunc")]
        public void RsOpIsNotNull_CreateFunc_WhenNotNull_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var rsOpIsNull = new RsOpIsNotNull();

            //------------Execute Test---------------------------
            var func = rsOpIsNull.CreateFunc(new List<DataASTMutable.WarewolfAtom> { DataASTMutable.WarewolfAtom.Nothing }, null, null, false);
            var isNull = func.Invoke(DataASTMutable.WarewolfAtom.NewDataString("bob"));
            //------------Assert Results-------------------------
            Assert.IsTrue(isNull);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("RsOpIsNotNull_HandlesType")]
        public void RsOpIsNotNull_HandlesType_ReturnsIsNotNULL()
        {
            //------------Setup for test--------------------------
            var rsOpIsNull = new RsOpIsNotNull();
            
            //------------Execute Test---------------------------
            var handlesType = rsOpIsNull.HandlesType();
            //------------Assert Results-------------------------
            Assert.AreEqual("Is Not NULL",handlesType);
        }
    }
}