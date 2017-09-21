using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class InventoryFileDAL
    {
        Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

        public Dictionary<string, List<VendingMachineItem>> GetDictionary()
        {
            return inventory;
        }
        public InventoryFileDAL()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "vendingmachine.csv";
            string fullFilePath = Path.Combine(currentDirectory, path);

            


            try
            {
                using (StreamReader sr = new StreamReader(fullFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string nextLine = sr.ReadLine();
                        List<string> itemList = nextLine.Split('|').ToList();
                        if (itemList[0].Contains("A"))
                        {
                            List<VendingMachineItem> chips = new List<VendingMachineItem>();

                            ChipItem chip = new ChipItem(itemList[1], Decimal.Parse(itemList[2]));
                            for (int i = 0; i < 5; i++)
                            {
                                chips.Add(chip);
                            }
                            inventory.Add(itemList[0], chips);
                        }
                        else if (itemList[0].Contains("B"))
                        {
                            List<VendingMachineItem> candies = new List<VendingMachineItem>();

                            CandyItem candy = new CandyItem(itemList[1], Decimal.Parse(itemList[2]));
                            for (int i = 0; i < 5; i++)
                            {
                                candies.Add(candy);
                            }
                            inventory.Add(itemList[0], candies);
                        }
                        else if (itemList[0].Contains("C"))
                        {
                            List<VendingMachineItem> beverages = new List<VendingMachineItem>();

                            BeverageItem beverage = new BeverageItem(itemList[1], Decimal.Parse(itemList[2]));
                            for (int i = 0; i < 5; i++)
                            {
                                beverages.Add(beverage);
                            }
                            inventory.Add(itemList[0], beverages);
                        }
                        else if (itemList[0].Contains("D"))
                        {
                            List<VendingMachineItem> gums = new List<VendingMachineItem>();

                            GumItem gum = new GumItem(itemList[1], Decimal.Parse(itemList[2]));
                            for (int i = 0; i < 5; i++)
                            {
                                gums.Add(gum);
                            }
                            inventory.Add(itemList[0], gums);
                        }


                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
