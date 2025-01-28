using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class task1
    {   

        public void countdigit(int num)
        {
            int oddcount = 0;
            int evencount = 0;
            while (num > 0)
            {
                int digit = Convert.ToInt32(num % 10); 
                if (digit % 2 == 0)
                    evencount++;
                else
                    oddcount++; 

                num /= 10; 
            }
            Console.WriteLine($"The odd-count of the number is {oddcount} ");
            Console.WriteLine($"The even-count of the number is {evencount} ");
        }

    }
}
