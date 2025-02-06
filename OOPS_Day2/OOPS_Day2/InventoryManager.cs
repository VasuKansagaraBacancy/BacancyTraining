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
        public void AddProduct(StockLogger stockLogger)
        {
            Console.WriteLine("Enter the Product ID");
            int ItemID=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Product Name");
            string Name=Console.ReadLine();

            Console.WriteLine("Enter the Product Price");
            int price=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Product Stock");
            int stock=Convert.ToInt32(Console.ReadLine());

            products.Add(new Product(ItemID, Name, price, stock));
            Console.WriteLine("Product Added.");
            stockLogger.LogStockUpdate(ItemID,stock, "Added");
        }

        public void RemoveProduct(int productID, StockLogger stockLogger)
        {
            var product = products.FirstOrDefault(p => p._ItemID == productID);
            if (product != null)
            {
                Console.WriteLine($"Product {product._Name} removed.");
                stockLogger.LogStockUpdate(product._ItemID, product._stock, "Removed");
                products.Remove(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

    partial class InventoryManager : IInventoryOperations
    {
        public void UpdateStock(int productID, int quantity, bool isRestock)
        {
            var product = products.FirstOrDefault(p => p._ItemID == productID);
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
