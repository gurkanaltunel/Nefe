using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nefe.Domain;

namespace Nefe.Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product pro = new Product();
            pro.UnitPrice = 5.5M;
            pro.Quantity = 3;
            Assert.IsTrue(pro.TotalPrice == 16.5M, "Yes");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Product pro = new Product();
            pro.TotalStockAmount = 3;
            pro.Quantity = 3;
            Assert.IsTrue(pro.StockStatus, "stokta var");
        }

        [TestMethod]
        public void TestEnumValueString()
        {
            var strValue = OrderStatus.Approved.ToString();
            Assert.AreEqual(strValue, "Approved");
        }

        [TestMethod]
        public void TestStringNullValue()
        {
            string testStr = null;
            string testStr2 = testStr ?? "yyy";
            Assert.AreEqual(testStr, testStr2);
        }
    }
}
