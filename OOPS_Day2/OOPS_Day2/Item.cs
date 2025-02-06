using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    public class Item
    {
        public int ItemID { get;private set; }
        public string Name { get;private set;}
        public Item(int itemID, string name)
        {
            ItemID=itemID;
            Name=name;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ItemID : {ItemID}\nItemName : {Name}");
        }
    }
}
