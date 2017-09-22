using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.Exception_Classes;

namespace Capstone.Classes
{

    public class VendingMachineCLI
    {
        public VendingMachine ourVM = new VendingMachine();

        public void Display()
        {

            PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                string input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    Submenu1CLI submenu = new Submenu1CLI();
                    submenu.Display();
                }
                else if (input == "2")
                {
                    Submenu2CLI submenu = new Submenu2CLI(ourVM);
                    submenu.Display();
                }



            }
        }

        public class Submenu1CLI
        {


            public void Display()
            {
                Dictionary<string, List<VendingMachineItem>> Inventory = new Dictionary<string, List<VendingMachineItem>>();
                InventoryFileDAL IFD = new InventoryFileDAL();
                Inventory = IFD.GetDictionary();


                foreach (var kvp in Inventory)
                {

                    Console.WriteLine((kvp.Key) + " " + (kvp.Value[0].Name) + " " + (kvp.Value[0].Price.ToString("C")));

                }
            }
        }

        public class Submenu2CLI
        {
            List<VendingMachineItem> totalProductsSelected = new List<VendingMachineItem>();
            private VendingMachine VM;
            Change change;
            TransactionFileLog logger = new TransactionFileLog();

            public Submenu2CLI(VendingMachine VM)
            {
                this.VM = VM;
            }
            public void Display()
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine();
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        try
                        {


                            Console.WriteLine("How many dollars would you like to insert?");
                            int fedMoney = Int32.Parse(Console.ReadLine());
                            logger.RecordDeposit(fedMoney, (VM.CurrentBalance + fedMoney));
                            VM.FeedMoney(fedMoney);
                        }
                        catch(FormatException)
                        {
                            Tools.ColorfulWriteLine("Please only enter a whole Dollar Value" , ConsoleColor.Red);
                            Console.Beep();
                        }

                        }
                    else if (input == "2")
                    {

                        Console.WriteLine("Please select your product.");
                        Console.WriteLine();
                        string slotId = Console.ReadLine().ToUpper();
                        VendingMachineItem productSelected = VM.GetItemAtSlot(slotId);

                        

                        if (productSelected != null)
                        {
                            
                            totalProductsSelected.Add(productSelected);
                            logger.RecordPurchase(productSelected.Name, slotId, VM.CurrentBalance, VM.CurrentBalance - productSelected.Price);
                        }

                    }
                    else if (input == "3")
                    {
                        change = VM.returnChange();
                        Console.WriteLine("Your change is:");
                        Console.WriteLine(change.Quarters + " in quarters, " + change.Dimes + " in dimes, " + change.Nickels + " in nickels");
                        Console.WriteLine();
                        logger.RecordCompleteTransaction(change.TotalChange, VM.CurrentBalance);
                        for (int i = 0; i < totalProductsSelected.Count; i++)
                        {
                            Console.WriteLine(totalProductsSelected[i].Consume());
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a valid option?");
                    }

                    Console.WriteLine(VM.CurrentBalance.ToString("C"));
                }


            }
        }

        private void PrintHeader()
        {
            Tools.ColorfulWrite("WELCOME!",ConsoleColor.Yellow);
        }
    }
}
