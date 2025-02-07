using Day3;

Task3 t3 = new Task3();

Console.WriteLine("Enter the number of integers:");
int numCount = Convert.ToInt32(Console.ReadLine());
List<int> numbers = new List<int>();
Console.WriteLine("Enter the numbers:");
for (int i = 0; i < numCount; i++)
{
    numbers.Add(Convert.ToInt32(Console.ReadLine()));
}

Console.WriteLine("Before Sorting: ");
t3.Displaylist(numbers);
t3.Sortlist(numbers);

Console.WriteLine("After Sorting: ");
t3.Displaylist(numbers);


Console.WriteLine("Enter the number of words:");
int wordCount = Convert.ToInt32(Console.ReadLine());
List<string> words = new List<string>();
Console.WriteLine("Enter the words:");
for (int i = 0; i < wordCount; i++)
{
    words.Add(Console.ReadLine());
}       

Console.WriteLine("Before Sorting: ");
t3.Displaylist(words);

t3.Sortlist(words);

Console.WriteLine("After Sorting: ");
t3.Displaylist(words);

//Task3 t3 = new Task3();

//List<int> numbers = new List<int> { 55, 5, 555, 55555, 5555 };
//Console.WriteLine("Before Sorting: ");
//t3.Displaylist(numbers);

//t3.Sortlist(numbers);

//Console.WriteLine("After Sorting: ");
//t3.Displaylist(numbers);

//List<string> words = new List<string> { "Vasu", "Kajal", "Shubh", "Moxshang", "Ishika" };
//Console.WriteLine("Before Sorting: ");


//t3.Displaylist(words);

//t3.Sortlist(words);

//Console.WriteLine("After Sorting: ");

//t3.Displaylist(words);