using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class VendingMachine

        
    {
        Dictionary<string, List<VendingMachineItem>> Inventory = new Dictionary<string, List<VendingMachineItem>>();

        public Change customersChange;
        private string[] slots;



        private decimal curerntBalance;

        public decimal CurrentBalance
        {
            get { return curerntBalance; }
           
        }




        public string[] Slots
        {
            get { return slots; }
           
        }

        public void FeedMoney(int dollars)
        {
            curerntBalance +=  dollars;
        }

        public Change returnChange()
        {
            this.curerntBalance = CurrentBalance * 100;
            //customersChange = Change(this.curerntBalance);
            decimal amountToReturn = this.curerntBalance;
            this.curerntBalance = 0;
            return new Change(amountToReturn);
        }

        public VendingMachine()
        {
            InventoryFileDAL IFD = new InventoryFileDAL();
            Inventory =  IFD.GetDictionary();
          
        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> Inventory )
        {

        }



        public VendingMachineItem GetItemAtSlot(string slotId)
        {
            List<VendingMachineItem> ourSlotDevice = new List<VendingMachineItem>();
            ourSlotDevice = Inventory[slotId];
            string price = ourSlotDevice[0].Price.ToString();
            string name = ourSlotDevice[0].Name;
            string[] nameArray = new string[] { name, price };
            this.slots = nameArray;


            List<VendingMachineItem> itemWantedList = new List<VendingMachineItem>();
            itemWantedList = Inventory[slotId];

            if (itemWantedList[0].Price <= curerntBalance && itemWantedList.Count > 0)
            {
                itemWantedList.RemoveAt(0);
                curerntBalance -= itemWantedList[0].Price;
                return itemWantedList[0];
            }

            else
            {
                return null;
            }













            //List<VendingMachineItem> items = Inventory[slotId];
            //VendingMachineItem typeOfItem = items[0];

            //if (Inventory[slotId].Count > 0 && typeOfItem.Price <= CurrentBalance)
            //{
            //    Inventory[slotId] = Inventory[slotId].RemoveAt(0);
            //    return typeOfItem.Name;
            //}
            //else if (Inventory[slotId].Count == 0 && typeOfItem.Price <= CurrentBalance)
            //{
            //    return typeOfItem.Name + " is out of stock";
            //}
            //else
            //{
            //    return "You do not have enough money!";
            //}
        }


    }
}
