using EF_CORE_Day4.Data;
using EF_CORE_Day4.DTO;
using EF_CORE_Day4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject([FromBody] ProjectDto dto)
        {
            if (string.IsNullOrEmpty(dto.ProjectName))
                return BadRequest("Project name is required.");

            var project = new Project
            {
                ProjectName = dto.ProjectName,
                StartDate = dto.StartDate
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project =  _context.Projects
                .Include(p => p.EmployeeProjects)
                .ThenInclude(ep => ep.Employee)
                .Where(p => p.ProjectId == id)
                .Select(p=>new { p.ProjectName, p.StartDate, ProjectEmployee = p.EmployeeProjects.Select(s => new {s.Employee.Name,s.Employee.Email})});

            if (project == null)
                return NotFound();

            
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDto dto)
        {
            if (string.IsNullOrEmpty(dto.ProjectName))
                return BadRequest("Project name is required.");

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            project.ProjectName = dto.ProjectName;
            project.StartDate = dto.StartDate;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.EmployeeProjects)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
                return NotFound();

            if (project.EmployeeProjects.Any())
                _context.EmployeeProjects.RemoveRange(project.EmployeeProjects);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
