using DOTNET_Day5;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [Authorize]
    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();
        return Ok(students);
    }
    [Authorize]
    [HttpPost]
    public IActionResult RegisterStudent([FromBody] Student student)
    {
        _studentService.AddStudent(student);
        return Ok(new { Message = "Student registered successfully!" });
    }
    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] Student student)
    {
        _studentService.UpdateStudent(id, student);
        return Ok(new { Message = "Student updated successfully!" });
    }
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentService.DeleteStudent(id);
        return Ok(new { Message = "Student Deleted successfully!" });
    }
}