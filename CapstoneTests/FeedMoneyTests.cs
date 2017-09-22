using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyTests
    {
        [TestMethod]
        public void FeedMoney()
        {
            VendingMachine Carl = new VendingMachine();
            Carl.FeedMoney(5);
            Assert.AreEqual(5,Carl.CurrentBalance);
        }
    }
}
