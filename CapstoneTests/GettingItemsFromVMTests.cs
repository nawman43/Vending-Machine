using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class GettingItemsFromVMTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            VendingMachine ourVM = new VendingMachine();
            ourVM.FeedMoney(5);
            ourVM.GetItemAtSlot("A1");
            Assert.AreEqual(195 , ourVM.CurrentBalance);
        }
    }
}
