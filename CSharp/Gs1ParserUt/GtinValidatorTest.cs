using Gs1Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gs1ParserUt
{
    [TestClass]
    public class GtinValidatorTest
    {
        [TestMethod]
        public void TestGtinValid14()
        {
            bool valid = new GtinValidator().Validate("90614141000411");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestGtinInvalid14()
        {
            bool valid = new GtinValidator().Validate("90614141000415");
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void TestGtinValid13()
        {
            bool valid = new GtinValidator().Validate("9401234567894");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestGtinValid12()
        {
            bool valid = new GtinValidator().Validate("614141000449");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestGtinValid8()
        {
            bool valid = new GtinValidator().Validate("50678907");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestGtinInvalidLength()
        {
            bool valid = new GtinValidator().Validate("506789076");
            Assert.IsFalse(valid);
        }
    }
}
