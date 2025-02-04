
using OOPS_Day1;

Product p=new Product();

p.addproduct(1, "Pen", 10, 100);
p.addproduct(2, "Pencil", 5, 200);
p.addproduct(3, "Chair", 5000, 500);
p.addproduct(4, "Laptop", 50000, 80);
p.addproduct(5, "Bag", 500, 500);

p.UpdateStock(2,500);
p.UpdateStock(1,0);

Console.WriteLine("Stock of the Pencil is "+ p.GetStockQuantity(2));

//pen.CreateProduct();
//GC.Collect();
//GC.WaitForPendingFinalizers();

Console.ReadKey();


