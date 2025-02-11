using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    partial class InventoryManager : IInventoryOperations
    {
        private List<Product> products = new List<Product>();
        public List<Product> GetProducts()
        {
            return products;
        }   
        void IInventoryOperations.AddProduct(StockLogger stockLogger)
        {
            try
            {
                Console.WriteLine("Enter the Product ID:");
                int itemID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Product Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Product Price:");
                int price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Product Stock:");
                int stock = Convert.ToInt32(Console.ReadLine());

                products.Add(new Product(itemID, name, price, stock));
                Console.WriteLine("Product Added.");
                stockLogger.LogStockUpdate(itemID, stock, "Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }
        void IInventoryOperations.RemoveProduct(int productID, StockLogger stockLogger)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.ItemID == productID);
                if (product != null)
                {
                    products.Remove(product);
                    Console.WriteLine($"Product {product.Name} removed.");
                    stockLogger.LogStockUpdate(product.ItemID, product.Stock, "Removed");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing product: {ex.Message}");
            }
        }
    }
    partial class InventoryManager : IInventoryOperations
    {
        public void UpdateStock(int productID, int quantity, bool isRestock)
        {
            var product = products.FirstOrDefault(p => p.ItemID == productID);
            if (product != null)
            {
                product.UpdateStock(quantity, isRestock);
            }
        }
        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }
    }
}