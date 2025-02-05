
using OOPS_Day1;

Product p=new Product();

Console.WriteLine("How many products do you want to enter?");
int Products= Convert.ToInt32(Console.ReadLine());

for (int i=0; i<Products; i++)
{
    p.AddProduct();
}

p.UpdateStock(2,500);
p.UpdateStock(1,0);

Console.WriteLine("Stock of the Pencil is "+ p.GetStockQuantity(2));

Console.ReadKey();


