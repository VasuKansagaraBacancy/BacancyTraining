using EF_CORE_Day4.Data;
using EF_CORE_Day4.DTO;
using EF_CORE_Day4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmployeeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Email))
                return BadRequest("Name and Email are required.");

            var departmentExists =  _context.Departments.Any(d => d.DepartmentId == dto.DepartmentId);
            if (!departmentExists)
                return BadRequest("Invalid DepartmentId.");

            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                .ThenInclude(p=>p.Project)
                .Where(e => e.EmployeeId == id)
                .Select(d => new
                {
                    d.Name,
                    d.Email,
                    d.Department.DepartmentName,
                    Projects = d.EmployeeProjects.Select(p => new
                    {
                        p.Project.ProjectName,
                        p.Project.StartDate
                    })
                });

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Email))
                return BadRequest("Name and Email are required.");

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            var departmentExists = await _context.Departments.AnyAsync(d => d.DepartmentId == dto.DepartmentId);
            if (!departmentExists)
                return BadRequest("Invalid DepartmentId.");

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.DepartmentId = dto.DepartmentId;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeProjects)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
