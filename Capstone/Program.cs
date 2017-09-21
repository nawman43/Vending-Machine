using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine ourVM = new VendingMachine();
            ourVM.FeedMoney(5);
            ourVM.FeedMoney(2);
            ourVM.GetItemAtSlot("C1");
            string[] array = ourVM.Slots;
            Console.WriteLine(array[0] + " " + array[1] );
         //   Console.WriteLine(ourVM.GetItemAtSlot("A1"));
            Console.WriteLine(ourVM.CurrentBalance);
        }
    }
}
