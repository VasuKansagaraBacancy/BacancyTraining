
using OOPS_Day1;

Product pen = new Product(1, "Pen", 10, 100);
Product pencil = new Product(2, "Pencil", 5, 200);
Product chair = new Product(3, "Chair", 5000, 500);
Product laptop = new Product(4, "Laptop", 50000,80);
Product bag = new Product(5,"Bag",500, 500);


pencil.UpdateStock(500);
pen.UpdateStock(0);

Console.WriteLine("Stock of the Pencil is "+ pencil.GetStockQuantity());

//pen.CreateProduct();
//GC.Collect();
//GC.WaitForPendingFinalizers();

Console.ReadKey();


