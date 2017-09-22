using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;


namespace Capstone.Classes
{
    public class TransactionFileLog
    {
        public TransactionFileLog()
        {

        }

        public void RecordCompleteTransaction(decimal initialAmount, decimal finalAmount)

        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);


            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.UtcNow + " Give Change " + (initialAmount /100).ToString("C") + " " +  finalAmount.ToString("C"));
            }
            
        }

        public void RecordDeposit(decimal despositAmount, decimal finalBalcance)

        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);


            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.UtcNow + " FEED MONEY " + despositAmount.ToString("C") + "  " + finalBalcance.ToString("C")  );
            }
        }

        public void RecordPurchase(string productName, string slotID, decimal initialBalance, decimal finalBalance)

        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);


            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.UtcNow  + productName + " " + slotID + " " + initialBalance.ToString("C") + "  " + finalBalance.ToString("C"));
            }
        }
    }
}

