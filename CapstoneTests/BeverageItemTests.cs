using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class BeverageItemTests
    {
        [TestMethod]
        public void BeverageNameAndPriceAreRight()
        {
            BeverageItem MtDew = new BeverageItem("MtDew", 100);
            Assert.AreEqual(100, MtDew.Price);
            Assert.AreEqual("MtDew", MtDew.Name);
            Assert.AreEqual("Glug Glug, Yum!", MtDew.Consume());
        }
    }
}
