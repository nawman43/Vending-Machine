﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class CandyItem : VendingMachineItem
    {

       public CandyItem(string itemName , decimal priceCents)
        {
            this.Price = priceCents;
            this.Name = itemName;
        }


        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
