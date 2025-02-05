using System;
using System.Collections.Generic;

namespace OOPS_Day1
{
    public class Product
    {
        private int ProductID { get; set; }
        private string Name { get; set; }
        private decimal Price { get; set; }
        private int StockQuantity { get; set; }

        public List<Product> Products = new List<Product>();

        public Product() { }

        public Product(int productID, string name, decimal price, int stockQuantity)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Console.WriteLine($"Item '{name}' is added at the price of {price} with a quantity of {stockQuantity}.");
        }

        public void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter the Product ID:");
                int productID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Product Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter the Stock Quantity:");
                int stockQuantity = Convert.ToInt32(Console.ReadLine());

                Products.Add(new Product(productID, name, price, stockQuantity));
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public int GetStockQuantity(int id)
        {
            foreach (Product p in Products)
            {
                if (p.ProductID == id)
                {
                    return p.StockQuantity; 
                }
            }
            Console.WriteLine("Invalid Product ID.");
            return -1;
        }

        public void UpdateStock(int id, int quantity)
        {
            try
            {
                if (quantity < 0)
                {
                    Console.WriteLine("Stock quantity cannot be negative.");
                    return;
                }

                foreach (Product p in Products)
                {
                    if (p.ProductID == id)
                    {
                        p.StockQuantity = quantity;
                        Console.WriteLine($"Updated Stock Quantity of '{p.Name}': {p.StockQuantity}");

                        if (quantity == 0)
                        {
                            Console.WriteLine($"Item '{p.Name}' (ID: {id}) is out of stock.");
                        }
                        return;
                    }
                }

                Console.WriteLine("Product ID not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        ~Product()
        {
            if (StockQuantity == 0)
            {
                Console.WriteLine("Destructor called: Item is out of stock.");
            }
        }
    }
}
