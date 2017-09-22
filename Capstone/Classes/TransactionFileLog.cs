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
                sw.WriteLine((DateTime.UtcNow).ToString().PadRight(30) + " Give Change ".PadRight(30) + (initialAmount /100).ToString("C").PadRight(31) + " " +  finalAmount.ToString("C"));
            }
            
        }

        public void RecordDeposit(decimal despositAmount, decimal finalBalcance)

        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);


            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.UtcNow.ToString().PadRight(30) + " FEED MONEY ".PadRight(30) + despositAmount.ToString("C").PadRight(30) + "  " + finalBalcance.ToString("C")  );
            }
        }

        public void RecordPurchase(string productName, string slotID, decimal initialBalance, decimal finalBalance)

        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);


            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.UtcNow.ToString().PadRight(30)  + productName + " " + slotID.PadRight(20) + " " + initialBalance.ToString("C").PadRight(30) + "  " + finalBalance.ToString("C"));
            }
        }
    }
}

