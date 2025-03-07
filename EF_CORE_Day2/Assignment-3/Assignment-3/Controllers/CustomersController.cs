using Assignment_3.Data;
using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
           _context=context;
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers=_context.Customers.ToList();
            return Ok(customers);
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody]Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound(); 
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(new { message = "Customer deleted successfully" });
        }
    }
}