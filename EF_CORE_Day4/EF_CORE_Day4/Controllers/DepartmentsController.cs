using EF_CORE_Day4.Data;
using EF_CORE_Day4.DTO;
using EF_CORE_Day4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            if (string.IsNullOrEmpty(dto.DepartmentName))
                return BadRequest("Department name is required.");

            var department = new Department
            {
                DepartmentName = dto.DepartmentName
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return Ok(department);
        }

        [HttpGet]
        public ActionResult<Department> GetDepartments()
        {
            var departments = _context.Departments.Select(d => new { d.DepartmentId, d.DepartmentName });

            if (departments == null)
                return NotFound();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentDetails(int id)
        {
            var department =  _context.Departments
                .Include(d => d.Employees)
                .Where(d => d.DepartmentId == id)
                .Select(d => new { d.DepartmentId, d.DepartmentName, Employees = d.Employees.Select(d => new { d.Name, d.Email, d.EmployeeId }) });

            if (department == null)
                return NotFound();

             return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] CreateDepartmentDto dto)
        {
            if (string.IsNullOrEmpty(dto.DepartmentName))
                return BadRequest("Department name is required.");

            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
                return NotFound();

            existingDepartment.DepartmentName = dto.DepartmentName;

            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
