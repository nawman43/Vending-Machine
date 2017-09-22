using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;


namespace Capstone.Exception_Classes
{
   public class InsuffiecientFundsException : VendingMachineExceptions
    {
        private Exception ex;
        private string v;

        public InsuffiecientFundsException(string v, Exception ex)
        {
            this.v = v;
            this.ex = ex;
        }
    }
}
