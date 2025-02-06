using System;

namespace OOPS_Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();
            StockLogger stockLogger = new StockLogger();

            Console.WriteLine("Howmany products do you want to enter");
            int products =Convert.ToInt32(Console.ReadLine()); 

            for(int i=0;i<products;i++)
            {
                inventoryManager.AddProduct(stockLogger);
            }

            Console.WriteLine("\n--- Inventory Products ---");
            inventoryManager.DisplayProducts();

            Console.WriteLine("\nUpdating Stock:");
            inventoryManager.UpdateStock(101, 5, true); 
            inventoryManager.UpdateStock(102, 3, false);
          
            Console.WriteLine("\n--- Updated Inventory Products ---");
            inventoryManager.DisplayProducts();
     
            Console.WriteLine("\nRemoving Product:");
            inventoryManager.RemoveProduct(1, stockLogger);

            Console.WriteLine("\n--- Final Inventory Products ---");
            inventoryManager.DisplayProducts();

            Console.WriteLine("\n--- Stock Logs ---");
           
            stockLogger.PrintAllLogs();

            Console.ReadLine();
        }
    }
}

