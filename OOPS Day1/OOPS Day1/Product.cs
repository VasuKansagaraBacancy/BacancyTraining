using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day1
{
    public class Product    
    {
        private int ProductID;
        private string Name;
        private decimal Price;
        private int StockQuantity;

        public List<Product> Products=new List<Product>();

        public Product() {}
        public Product(int productID, string name, decimal price, int stockQuantity)
        {
            Console.WriteLine($"Item {name} is added at the price of {price} in the quantity of {stockQuantity}");
            ProductID = productID;
            Name = name;
            Price = price;
            StockQuantity=stockQuantity;
        }

        public void addproduct(int productID, string name, decimal price, int stockQuantity)
        {
            Products.Add(new Product(productID, name, price, stockQuantity));
        }
        public int GetStockQuantity(int id)            
        {
            foreach (Product p in Products)
            {
                if (p.ProductID==id)
                {
                    return StockQuantity; 
                }
            }
            Console.WriteLine("Enter valid Product ID");
            return -1;       
        }

        public void UpdateStock(int id, int quantity)
        {
            if (quantity>=0)
            {
                foreach(Product p in Products)
                {
                  if(p.ProductID==id)
                    {
                        StockQuantity = quantity;
                        Console.WriteLine($"Updated Stock quantity of {p.Name} :{p.StockQuantity}");
                    }
                }               
            }
            else
            {
                Console.WriteLine("Stock quantity cannot be negative");                
            }
           if(quantity==0)
                {
                Console.WriteLine($"Item No. {id} is out of stock");

            }
        }                   
        ~Product() 
        {         
            if (StockQuantity == 0)
            {
                Console.WriteLine(" Destructor called : Item  is out of stock");
            }         
        }


        //public void CreateProduct()
        //{
        //    Product penn = new Product(1, "Penn", 10, 100);
        //    penn.UpdateStock(0);
        //} 

        
        
    }
}
