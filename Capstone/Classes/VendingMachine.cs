using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.Exception_Classes;


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
            curerntBalance += dollars;
        }

        public Change returnChange()
        {
            this.curerntBalance = CurrentBalance * 100;
           
            decimal amountToReturn = this.curerntBalance;
            this.curerntBalance = 0;
            return new Change(amountToReturn);
        }

        public VendingMachine()
        {
            InventoryFileDAL IFD = new InventoryFileDAL();
            Inventory = IFD.GetDictionary();

        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> Inventory)
        {

        }
        
        public VendingMachineItem GetItemAtSlot(string slotId)
        {
            List<VendingMachineItem> itemWantedList = new List<VendingMachineItem>();
            List<VendingMachineItem> ourSlotDevice = null;

            try
            {
                
                ourSlotDevice = Inventory[slotId];
                string price = ourSlotDevice[0].Price.ToString();
                string name = ourSlotDevice[0].Name;
                string[] nameArray = new string[] { name, price };
                this.slots = nameArray;


                itemWantedList = Inventory[slotId];

                if (itemWantedList[0] == null)
                {
                    throw new Exception();
                }

                else if (itemWantedList[0].Price <= curerntBalance && itemWantedList.Count > 0)
                {
                    VendingMachineItem item = itemWantedList[0];

                 
                    curerntBalance -= itemWantedList[0].Price;
                    itemWantedList.RemoveAt(0);

                    return item;
                }
                else if (itemWantedList[0].Price > curerntBalance)
                {
                    throw new Exception();
                }

                else
                {
                    return null;
                }


            }

            catch (Exception ex)
            {
                if (ourSlotDevice == null)
                {
                    InvalidSlotIdException x = new InvalidSlotIdException("This slot does not exist", ex);
                    {
                        Beepers annoy = new Beepers();
                        annoy.BeepTetris();

                        Tools.ColorfulWriteLine("This slot does not exist" , ConsoleColor.Red);
                    }
                }

               else if (itemWantedList.Count == 0)
                {
                    Console.Beep();
                    OutOfStockException x = new OutOfStockException("This item is out of stock", ex);
                    Tools.ColorfulWriteLine("This item is out of stock" , ConsoleColor.Red);
                }

                else if (itemWantedList[0].Price > curerntBalance)
                {
                    Console.Beep();
                    InsuffiecientFundsException x = new InsuffiecientFundsException("You do not have enough money", ex);
                    Tools.ColorfulWriteLine("You do not have enough money" , ConsoleColor.Red);
                }
                

                return null;
            }

            
        }


    }
}  
