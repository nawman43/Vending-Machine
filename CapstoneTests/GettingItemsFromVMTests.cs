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
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();
            ChipItem PotatoCrisp = new ChipItem("Potato Crisp", 3.05M);
            List<VendingMachineItem> PotatoCrisps = new List<VendingMachineItem>();
            PotatoCrisps.Add(PotatoCrisp);
            PotatoCrisps.Add(PotatoCrisp);
            PotatoCrisps.Add(PotatoCrisp);
            PotatoCrisps.Add(PotatoCrisp);
            PotatoCrisps.Add(PotatoCrisp);
            inventory.Add("A1", PotatoCrisps);

            VendingMachine whatever = new VendingMachine(inventory);
            
            
            VendingMachineItem item = whatever.GetItemAtSlot("A1");
            Assert.AreEqual(3.05, item.Price);
        }
    }
}
