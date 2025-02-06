using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    interface IInventoryItem
    {
        int  CalculateStockValue();
        void PrintInventoryReport();
    }
}