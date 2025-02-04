
using OOPS_Day1;

Product p=new Product();

p.addproduct();
p.addproduct();
p.addproduct();
p.addproduct();
p.addproduct();


p.UpdateStock(2,500);
p.UpdateStock(1,0);

Console.WriteLine("Stock of the Pencil is "+ p.GetStockQuantity(2));

//pen.CreateProduct();
//GC.Collect();
//GC.WaitForPendingFinalizers();

Console.ReadKey();


