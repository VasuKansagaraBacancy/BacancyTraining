// See https://aka.ms/new-console-template for more information


using Day3;

Task3 t3 = new Task3();

List<int> numbers = new List<int> { 55, 5, 555, 55555, 5555 };
Console.WriteLine("Before Sorting: ");
t3.Displaylist(numbers);

t3.Sortlist(numbers);

Console.WriteLine("After Sorting: ");
t3.Displaylist(numbers);

List<string> words = new List<string> { "Vasu", "Kajal", "Shubh", "Moxshang", "Ishika" };
Console.WriteLine("Before Sorting: ");


t3.Displaylist(words);

t3.Sortlist(words);

Console.WriteLine("After Sorting: ");

t3.Displaylist(words);