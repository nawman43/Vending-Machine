using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class VendingMachine

        
    {
       Dictionary<string, List<VendingMachineItem>> Inventory = new Dictionary<string , List<VendingMachineItem>>();
        


        private decimal curerntBalance;

        public decimal CurrentBalance
        {
            get { return curerntBalance; }
           
        }



        private string[] slots;

        public string[] Slots
        {
            get { return slots; }
           
        }

        public void FeedMoney(int dollars)
        {
            curerntBalance += 100 * dollars;
        }

        public string GetItemAtSlot(string slotId)
        {

            List<VendingMachineItem> items = Inventory[slotId];
            VendingMachineItem typeOfItem = items[0];

            if(Inventory[slotId].Count > 0 && typeOfItem.Price <= CurrentBalance)
            {
                Inventory[slotId] = Inventory[slotId].RemoveAt(0);
                return typeOfItem.Name;
            }
            else if (Inventory[slotId].Count == 0 && typeOfItem.Price <= CurrentBalance)
            {
                return typeOfItem.Name + " is out of stock";
            }
            else
            {
                return "You do not have enough money!";
            }
        }


    }
}
