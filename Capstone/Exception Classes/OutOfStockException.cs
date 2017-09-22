using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
namespace Capstone.Exception_Classes
{
   public class OutOfStockException : VendingMachineExceptions
    {
        private string v;
        private Exception ex;

       

        public OutOfStockException(string v, Exception ex)
        {
            this.v = v;
            this.ex = ex;
        }
    }
}
