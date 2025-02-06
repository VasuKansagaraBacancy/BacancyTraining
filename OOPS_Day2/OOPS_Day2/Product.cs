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
            if (isRestock) {
                _stock += quantity;
                Console.WriteLine($"Stock updated. New Stock: {_stock}");
            }
            else
            {
                _stock -= quantity;
                Console.WriteLine($"Stock updated. New Stock: {_stock}");
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
