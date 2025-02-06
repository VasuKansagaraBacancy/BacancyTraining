﻿using System;

namespace OOPS_Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();
            StockLogger stockLogger = new StockLogger();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. View Stock Logs");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            inventoryManager.AddProduct(stockLogger);
                            break;
                        case 2:
                            Console.WriteLine("\n--- Inventory Products ---");
                            inventoryManager.DisplayProducts();
                            break;
                        case 3:
                            Console.Write("Enter Product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Restock? (true/false): ");
                            bool isRestock = Convert.ToBoolean(Console.ReadLine());
                            inventoryManager.UpdateStock(productId, quantity, isRestock);
                            break;
                        case 4:
                            Console.Write("Enter Product ID to Remove: ");
                            int removeId = Convert.ToInt32(Console.ReadLine());
                            inventoryManager.RemoveProduct(removeId, stockLogger);
                            break;
                        case 5:
                            Console.WriteLine("\n--- Stock Logs ---");
                            stockLogger.PrintAllLogs();
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Occured{ex.Message}");
                }
            }
        }
    }
}


