# Password Validity Checker

## Overview
This project is a simple console application written in C# to evaluate the validity of a password based on the following criteria:

1. The password must be at least **8 characters long**.
2. It must contain **at least one uppercase letter**.
3. It must contain **at least one lowercase letter**.
4. It must include **at least one digit**.
5. It must include **at least one special character** (e.g., `@`, `#`, `!`, etc.).

## How to Use

1. Open a C# development environment, such as Visual Studio or any text editor with a .NET compiler.
2. Copy the provided code into a new C# Console Application project.
3. Build and run the program.
4. Enter a password when prompted, and the program will evaluate its strength based on the criteria.

  ## Code

```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class task2
    {
        public bool isvalid(string pw)
        {
            if(pw.Length<8)
            {
                Console.WriteLine("invalid password");
                return false;
            }
            bool upper = false;
            bool lower = false;
            bool digit = false;
            bool special = false;

            foreach (char ch in pw) {
                if (char.IsUpper(ch)) {
                    upper = true;
                }
                if (char.IsLower(ch))
                {
                    lower = true;
                }
                if (char.IsDigit(ch))
                {
                    digit = true;
                }
                if (isspecial(ch))
                {
                    special = true;
                }
            }

            if (upper && lower &&  digit && special) {
                Console.WriteLine("valid password");
                return true;
            }
            Console.WriteLine("invalid password");
            return false;
        }

        public bool isspecial(char ch) {
            string special = "!@#$%^&*(),.?\":{}|<>";
            return special.Contains(ch);
        }
    }
}
```
## Expected Output

- If the password meets all the criteria, the program will display:  
  **valid password**

- If the password does not meet one or more criteria, the program will display:  
  **invalid password**  
  followed by a list of missing criteria.
  
## Example

**Input:**  
`V@su5555`  

**Output:**  
`valid password`  

**Input:**  
`vasu55`  

**Output:**  
`invalid password`  


## Requirements

- .NET Framework or .NET Core
- Basic knowledge of running C# Console Applications














## Authors

- [Vasu Kansagara](https://github.com/VasuKansagaraBacancy)

