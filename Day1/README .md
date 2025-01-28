
# Count Occurrences of Odd and Even Digits

This C# program counts the occurrences of odd and even digits in a given integer input. It takes an integer as input from the user, processes each digit, and calculates the number of odd and even digits.

## Features
- Accepts integer input from the user.
- Processes each digit to determine if it is odd or even.
- Displays the count of odd and even digits.


## How It Works
1. The user inputs an integer.
2. The program extracts each digit of the number.
3. Each digit is checked to determine if it is odd or even.
4. Counts for odd and even digits are incremented accordingly.
5. Results are displayed.

## Code
```csharp
﻿using System;
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
```

## Example
### Input:
```
Enter the number of which you want to find the count of odd and even digits.
123456
```

### Output:
```
The odd-count of the number is 3
The even-count of the number is 3
```

## How to Run the Program
1. Copy the code into a C# development environment (e.g., Visual Studio ).
2. Build and run the program.
3. Input an integer when prompted.
4. View the counts of odd and even digits in the output.








## Authors

- [Vasu Kansagara](https://github.com/VasuKansagaraBacancy)

