using EF_CORE_Day3.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LazyController : Controller
    {
        private readonly AppDbContext _context;

        public LazyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("lazy-loading-orders-with-customers")]
        public IActionResult GetOrdersWithCustomers()
        {
            var orders = _context.Orders
                .Where(o => !o.IsDeleted)
                .ToList(); 

            var orderDtos = orders.Select(order =>
            {
                var customer = order.Customer;

                Console.WriteLine($"Loaded Order {order.Id} for Customer {customer.Name}");

                return new OrderWithCustomerDto
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    Customer = new CustomerDto
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Email = customer.Email 
                    }
                };
            }).ToList();

            return Ok(orderDtos);
        }

        [HttpGet("lazy-loading-orders-over-500")]
        public IActionResult GetOrdersOver500()
        {
            var orders = _context.Orders
                .Where(o => !o.IsDeleted)
                .ToList();

            var qualifyingOrders = new List<OrderWithCustomerDto>();

            foreach (var order in orders)
            {
                var totalAmount = order.OrderProducts
                    .Sum(op => op.Quantity * op.Product.Price);

                if (totalAmount > 500)
                {
                    var customer = order.Customer;

                    Console.WriteLine($"Order {order.Id} qualifies with total amount {totalAmount}");

                    qualifyingOrders.Add(new OrderWithCustomerDto
                    {
                        OrderId = order.Id,
                        OrderDate = order.OrderDate,
                        Customer = new CustomerDto
                        {
                            CustomerId = customer.Id,
                            Name = customer.Name,
                            Email = customer.Email 
                        }
                    });
                }
                else
                {
                    Console.WriteLine($"Order {order.Id} skipped with total amount {totalAmount}");
                }
            }

            return Ok(qualifyingOrders);
        }
    }
}
