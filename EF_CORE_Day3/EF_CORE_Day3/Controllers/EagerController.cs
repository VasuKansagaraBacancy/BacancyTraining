using EF_CORE_Day3.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EagerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EagerController(AppDbContext context)
        {                                   
            _context = context;
        }
        [HttpGet("customers-with-orders-orderproducts")]
        public IActionResult GetCustomersWithOrdersAndOrderProducts()
        {
            var customers = _context.Customers
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderProducts)
                        .ThenInclude(op => op.Product)
                .ToList();

            var result = customers.Select(c => new
            {
                c.Id,
                c.Name,
                c.Email,
                Orders = c.Orders.Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    Products = o.OrderProducts.Select(op => new
                    {
                        op.ProductId,
                        op.Product.Name,
                        op.Product.Price,
                        op.Quantity
                    }).ToList()
                }).ToList()
            });

            return Ok(result);
        }


        [HttpGet("customers-with-recent-orders-and-instock-products")]
        public IActionResult GetCustomersWithRecentOrdersAndInStockProducts()
        {
            DateTime last30Days = DateTime.UtcNow.AddDays(-30);

            var customers = _context.Customers
                .Include(c => c.Orders.Where(o => o.OrderDate >= last30Days))
                    .ThenInclude(o => o.OrderProducts)
                        .ThenInclude(op => op.Product)
                .ToList();

            var result = customers.Select(c => new
            {
                c.Id,
                c.Name,
                c.Email,
                Orders = c.Orders.Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    Products = o.OrderProducts
                        .Where(op => op.Product.Stock > 20)
                        .Select(op => new
                        {
                            op.ProductId,
                            op.Product.Name,
                            op.Product.Price,
                            op.Product.Stock,
                            op.Quantity
                        }).ToList()
                }).Where(o => o.Products.Any())
                .ToList()
            }).Where(c => c.Orders.Any()) 
            .ToList();

            return Ok(result);
        }

        [HttpGet("products-with-order-count")]
        public IActionResult GetProductsWithOrderCount()
        {
            var products = _context.Products
                .Include(p => p.OrderProducts)
                .Select(p => new ProductOrderCountDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    TotalOrders = p.OrderProducts
                        .Select(op => op.OrderId)
                        .Distinct()
                        .Count()
                })
                .ToList();

            return Ok(products);
        }


        [HttpGet("orders-last-month-with-customer")]
        public IActionResult GetOrdersLastMonthWithCustomer()
        {
            DateTime lastMonth = DateTime.UtcNow.AddMonths(-1);

            var orders = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.OrderDate >= lastMonth)
                .Select(o => new OrderWithCustomerDto
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    Customer = new CustomerDto
                    {
                        CustomerId = o.Customer.Id,
                        Name = o.Customer.Name,
                        Email = o.Customer.Email
                    }
                })
                .ToList();

            return Ok(orders);
        }

    }
}
