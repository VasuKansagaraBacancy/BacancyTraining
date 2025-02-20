using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
namespace DOTNET_Day3.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class StudentController : ControllerBase
        {
            private readonly ILogger<StudentController> _logger;
            private readonly IFileService _fileService;
        public StudentController(ILogger<StudentController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] List<Student> newStudents)
        {
            try
            {
                Student.students.AddRange(newStudents);

                string filePath = "studentData.txt";

                _fileService.SaveStudentsToFile(filePath, Student.students);

                return Ok("Student data added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while saving student data: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students= _fileService.RetriveStudentData();
            return Ok(students);
        }
    }
}
