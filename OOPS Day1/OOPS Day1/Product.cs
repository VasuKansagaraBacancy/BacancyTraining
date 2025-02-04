using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day1
{
    public class Product
    {
        public int ProductID;
        public string Name;
        public decimal Price;
        private int StockQuantity;

        public int GetStockQuantity()            
        {
            return StockQuantity;
        }

      


        public void UpdateStock(int quantity)
        {
            if (quantity>=0)
            {
                StockQuantity = quantity;
                Console.WriteLine($"Updated Stock quantity of {Name} :{StockQuantity}");
            }
            else
            {
                Console.WriteLine("Stock quantity cannot be negative");                
            }
           if(quantity==0)
                {
                Console.WriteLine($"Item {Name} is out of stock");

            }
        }

        public Product(int productID, string name, decimal price, int stockQuantity)
        {
            Console.WriteLine($"Item {name} is added at the price of {price} in the quantity of {stockQuantity}");
            ProductID = productID;
            Name = name;
            Price = price;
            StockQuantity=stockQuantity;
        }
           
        ~Product() {
           
            if (StockQuantity == 0)
            {
                Console.WriteLine(" Destructor called : Item  is out of stock");
            }
            
        }
        
    }
}
