using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day2
{
    interface IInventoryOperations
    {
        void AddProduct(StockLogger stockLogger);
        void RemoveProduct(int productID, StockLogger stockLogger);
        void DisplayProducts();
    } 
}