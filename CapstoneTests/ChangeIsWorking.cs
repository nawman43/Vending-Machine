using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeIsWorking
    {
        [TestMethod]
        public void Quarters()
        {
            Change change = new Change(235);
            Assert.AreEqual(9, change.Quarters);

        }

        [TestMethod]
        public void Dimes()
        {
            Change change = new Change(45);
            Assert.AreEqual(2, change.Dimes);
        }
    }
}
