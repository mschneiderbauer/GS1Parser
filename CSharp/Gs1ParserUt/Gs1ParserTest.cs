using Gs1Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gs1ParserUt
{
    [TestClass]
    public class Gs1ParserTest
    {
        [TestMethod]
        public void TestGS1128_1()
        {
            var parser = new GS1Parser();
            string code = "]C101040123456789011715012910ABC123@39329784711@310300052539224711@42127649716".Replace('@', (char)29); //to get fnc1
            var result = parser.Parse(code);

            Assert.AreEqual(result.Keys.Count, 7);
            Assert.IsTrue(result.ContainsKey("01"));
            Assert.IsTrue(parser.ContainsAI("01"));
            Assert.IsTrue(result.ContainsKey("17"));
            Assert.IsTrue(result.ContainsKey("10"));
            Assert.IsTrue(result.ContainsKey("393d"));
            Assert.IsTrue(result.ContainsKey("310d"));
            Assert.IsTrue(result.ContainsKey("421"));

            Assert.AreEqual(DateTime.Parse("29.1.2015"), (DateTime)parser.GetValue("17"));
            Assert.AreEqual((decimal)0.525, (decimal)parser.GetValue("310d"));
            Assert.AreEqual((decimal)0.525, parser.GetDecimal("310d"));
            Assert.AreEqual("ABC123", parser.GetString("10"));
        }

        [TestMethod]
        public void TestGS1128_2()
        {
            var parser = new GS1Parser();
            var result = parser.Parse("8005000365@10123456");

            Assert.AreEqual(result.Keys.Count, 2);
            Assert.IsTrue(result.ContainsKey("8005"));
            Assert.IsTrue(result.ContainsKey("10"));

            Assert.AreEqual(parser.GetString("8005"), "000365");
            Assert.AreEqual(365, parser.GetValue("8005"));
            Assert.AreEqual("123456", parser.GetValue("10"));
        }

        [TestMethod]
        public void TestGS1128_Batch()
        {
            var parser = new GS1Parser();
            var result = parser.Parse("10123456");

            Assert.AreEqual(result.Keys.Count, 1);
            Assert.IsTrue(result.ContainsKey("10"));

            Assert.AreEqual("123456", (string)parser.GetValue("10"));
        }
    }
}
