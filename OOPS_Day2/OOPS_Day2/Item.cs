using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    public class Item
    {
        public int _ItemID { get; set; }
        public string _Name { get; set;}
        public Item(int itemID, string name)
        {
            _ItemID=itemID;
            _Name=name;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ItemID : {_ItemID}\nItemName : {_Name}");
        }
    }
}
