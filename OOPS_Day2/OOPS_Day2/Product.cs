using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPS_Day2
{
    public class Product : Item, IInventoryItem
    {
        public int Price { get;private set; }
        public int Stock { get;private set; }
        public Product(int ItemID, string Name,int price,int stock) : base(ItemID, Name)
        { 
            Price = price;
            Stock = stock;
        }
        public void UpdateStock(int quantity)
        {
            Stock += quantity;
            Console.WriteLine($"Stock updated. New Stock: {Stock}");
        }
        public void UpdateStock(int quantity,bool isRestock)
        {
            try
            {
                if (isRestock)
                {
                    Stock += quantity;
                }
                else if (Stock >= quantity)
                {
                    Stock -= quantity;
                }
                else
                {
                    Console.WriteLine("Insufficient stock!");
                    return;
                }
                Console.WriteLine($"Stock updated. New Stock: {Stock}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stock: {ex.Message}");
            }
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ItemPrice : {Price}\nItemStock : {Stock}");
        }
        public int CalculateStockValue()
        {
            return Price * Stock;
        }
        public void PrintInventoryReport()
        {
            Console.WriteLine($"Inventory Report for Product: {Name}, Stock Value: {CalculateStockValue()}");
        }
    }
}