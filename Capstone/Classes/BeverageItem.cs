using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
  public  class BeverageItem : VendingMachineItem
    {
        public BeverageItem(string itemName, decimal priceCents)
        {
            this.Price = priceCents;
            this.Name = itemName;
        }


        public override string Consume()
        {
         return "Glug Glug, Yum!";
        }
    }
}
