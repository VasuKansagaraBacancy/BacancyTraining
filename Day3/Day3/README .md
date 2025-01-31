# Generic List Sorting 

## Overview
This project contains a generic class `Task3` that provides two main functionalities:
1. **Sortlist<T>**: A method to sort a list of elements using the Bubble Sort algorithm. It works for any type `T` that implements the `IComparable<T>` interface.
2. **Displaylist<T>**: A method to display the contents of a list of elements.

The `Sortlist<T>` method compares each adjacent element in the list and swaps them if they are out of order, repeatedly going through the list until it is sorted. The method can be used with any list containing elements that are comparable (i.e., those that implement `IComparable<T>`).

## Features
- **Sortlist<T>**: Sorts a list using the Bubble Sort algorithm.
- **Displaylist<T>**: Displays the elements of a list in a readable format.
- **Generics**: Works with any type `T` that implements `IComparable<T>`.

## Code Explanation

### Sortlist<T>
The `Sortlist<T>` method sorts a list using the Bubble Sort algorithm:
- **Bubble Sort** iterates over the list multiple times and swaps adjacent elements if they are out of order.
- The algorithm runs in **O(n²)** time complexity in the worst case, making it inefficient for large datasets but simple to implement for smaller or educational purposes.

### Displaylist<T>
The `Displaylist<T>` method displays each element of the list, separated by a space, followed by a newline.

## Usage Example

You can use the `Sortlist<T>` and `Displaylist<T>` methods with any type that implements the `IComparable<T>` interface (e.g., integers, strings, etc.).


 ## Code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Task3
    {
        public  void Sortlist<T>(List<T> list) where T : IComparable<T>
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

        }

        public void Displaylist<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
```
## How to Use

1. Open a C# development environment, such as Visual Studio or any text editor with a .NET compiler.
2. Copy the provided code into a new C# Console Application project.
3. Build and run the program.
4. Enter the list members and show the older and sorted list.

## Example Usage

**Input:**  
`Enter the number of integers: 5`

`Enter the numbers:
55
5
555
55555
5555`

**Output:**  
`Before Sorting:
55 5 555 55555 5555`

`After Sorting:
5 55 555 5555 55555`  

















## Authors

- [Vasu Kansagara](https://github.com/VasuKansagaraBacancy)

