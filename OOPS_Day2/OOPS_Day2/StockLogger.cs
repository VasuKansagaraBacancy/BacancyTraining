using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    sealed class StockLogger
    {
        private List<string> stockLogs=new List<string>();
        public void LogStockUpdate(int productID, int quantity, string action)
        {
            string logEntry = $"[{DateTime.Now}] ProductID: {productID}, Quantity: {quantity}, Action: {action}";
            stockLogs.Add(logEntry);
            Console.WriteLine(logEntry); 
        }
        public void PrintAllLogs()
        {
            Console.WriteLine("--- Stock Change Logs ---");
            foreach (var log in stockLogs)
            {
                Console.WriteLine(log);
            }
        }
    }
}