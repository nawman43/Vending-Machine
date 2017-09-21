using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class Change
    {
        decimal quarterValue = 25M;
        decimal dimeVaule = 10M;
        decimal nickleValue = 05M;


        private int nickels;

        public int Nickels
        {
            get { return nickels; }
          
        }


        private int dimes;

        public int Dimes
        {
            get { return dimes; }
            
        }

        private int quarters;

        public int Quarters
        {
            get { return quarters; }
           
        }


        private string totalChange;

        public string TotalChange
        {
            get { return totalChange; }
            
        }

        

    //    public Change(decimal amountOfDollars)
    //    {
            
    //    }


        public Change(decimal changeInCents)
        {

            totalChange = (changeInCents / 100).ToString("C");

            while(changeInCents / quarterValue >= 1)
            {
                quarters++;
                changeInCents -= quarterValue;
            }
            while(changeInCents / dimeVaule >= 1)
            {
                dimes++;
                changeInCents -= dimeVaule;
            }
            while(changeInCents / nickleValue >= 1)
            {
                nickels++;
                changeInCents -= nickleValue;
            }
            
                    
        }
    }
}
