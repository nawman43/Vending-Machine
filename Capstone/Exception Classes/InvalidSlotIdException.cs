﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Exception_Classes
{
  public  class InvalidSlotIdException : VendingMachineExceptions
    {
        private string v;
        private Exception ex;

        public InvalidSlotIdException(string v, Exception ex)
        {
            this.v = v;
            this.ex = ex;
        }
    }
}
