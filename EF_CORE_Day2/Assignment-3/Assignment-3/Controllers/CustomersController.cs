using Assignment_3.Data;
using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(customers);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = new Customer
            {
                Name = customerDto.Name
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(new CustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound(new { message = $"Customer with ID {id} not found." });

            customer.Name = customerDto.Name;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Customer Updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound(new { message = $"Customer with ID {id} not found." });

            customer.IsDeleted = true;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Customer soft-   deleted successfully." });
        }
        [HttpDelete("PermanentDeleteUser/{id}")]
        public async Task<IActionResult> PermanentDeleteUser(int id)
        {
            var existingUser = await _context.Customers.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.CustomerId == id);

            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            if(!existingUser.IsDeleted)
            {
                return BadRequest("You ahve to perform soft delete first");
            }
            _context.Customers.Remove(existingUser);
            await _context.SaveChangesAsync();
            return Ok($"Customer with ID {id} permanent deleted successfully.");
        }
    }
}
