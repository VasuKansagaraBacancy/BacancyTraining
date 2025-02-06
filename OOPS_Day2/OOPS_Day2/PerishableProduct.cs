using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOPS_Day2
{
    public class PerishableProduct : Item
    {
        private DateTime _expiration_date;
        public PerishableProduct(int ItemID,string Name, DateTime expiration_date) : base(ItemID, Name)
        {
        _expiration_date = expiration_date;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ItemExpiry : {_expiration_date}");
        }

    }
}
