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
        public int _price { get; set; }
        public int _stock { get; set; }
        public Product(int ItemID, string Name,int price,int stock) : base(ItemID, Name)
        { 
            _price = price;
            _stock = stock;
        }
        public void UpdateStock(int quantity)
        {
            _stock += quantity;
            Console.WriteLine($"Stock updated. New Stock: {_stock}");
        }
        public void UpdateStock(int quantity,bool isRestock)
        {
            try
            {
                if (isRestock)
                {
                    _stock += quantity;
                }
                else if (_stock >= quantity)
                {
                    _stock -= quantity;
                }
                else
                {
                    Console.WriteLine("Insufficient stock!");
                    return;
                }
                Console.WriteLine($"Stock updated. New Stock: {_stock}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stock: {ex.Message}");
            }
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ItemPrice : {_price}\nItemStock : {_stock}");
        }

        public int CalculateStockValue()
        {
            return _price * _stock;
        }

        public void PrintInventoryReport()
        {
            Console.WriteLine($"Inventory Report for Product: {_Name}, Stock Value: {CalculateStockValue()}");
        }
    }
}
