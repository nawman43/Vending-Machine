using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    
    public class VendingMachineCLI
    {
        public VendingMachine ourVM = new VendingMachine();
        public void Display()
        {
            
            PrintHeader();

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Submenu1CLI submenu = new Submenu1CLI();
                    submenu.Display();
                }
                else if(input == "2")
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
              
            }
        }

        public class Submenu2CLI
        {
            List<VendingMachineItem> totalProductsSelected = new List<VendingMachineItem>();
            private VendingMachine VM;
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
                        Console.WriteLine("How many dollars would you like to insert?");
                        int fedMoney = Int32.Parse(Console.ReadLine());
                        VM.FeedMoney(fedMoney);

                    }
                    else if (input == "2")
                    {

                       Console.WriteLine("Please select your product.");
                        string slotId = Console.ReadLine();
                        VendingMachineItem productSelected = VM.GetItemAtSlot(slotId);

                        if (productSelected != null)
                        {

                            totalProductsSelected.Add(productSelected);
                        }
                        else if(productSelected == null)
                            Console.WriteLine("Sorry, Item is out of stock");
                    }
                    else if (input == "3")
                    {


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
            Console.WriteLine("WELCOME!");
        }
    }
}
