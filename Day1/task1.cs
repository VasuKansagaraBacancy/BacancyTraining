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

        public void countnum(int num)
        {
            int oddcount = 0;
            int evencount = 0;
            for (int i = 1; i <= num; i++)
            {
             if(i % 2 == 0)
                {
                    evencount++;
                }
                else
                {
                    oddcount++;
                }

            }
            Console.WriteLine($"The odd-count till the {num} is {oddcount} ");
            Console.WriteLine($"The even-count till the {num} is {evencount} ");
        }

    }
}
