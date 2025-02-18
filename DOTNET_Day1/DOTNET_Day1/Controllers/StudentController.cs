using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace DOTNET_Day1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Post([FromBody] List<Student> newStudents)
        {
            try
            {
   
                Student.students.AddRange(newStudents);

                string filePath = "studentData.txt";
                string studentJson = JsonConvert.SerializeObject(Student.students, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, studentJson);

                return Ok("Student data added");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while saving student data: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string filePath = "studentData.txt";

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("No student data found.");
                }

                string studentJson = System.IO.File.ReadAllText(filePath);

                var students = JsonConvert.DeserializeObject<List<Student>>(studentJson);

                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while retrieving student data: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            try
            {
                var student = Student.students.FirstOrDefault(s => s.ID == id);

                if (student == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }

                student.Name = updatedStudent.Name;

                string filePath = "studentData.txt";
                string studentJson = JsonConvert.SerializeObject(Student.students, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, studentJson);

                return Ok("Student data updated and file updated.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while updating student data: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var student = Student.students.FirstOrDefault(s => s.ID == id);

                if (student == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }

                Student.students.Remove(student);

                string filePath = "studentData.txt";
                string studentJson = JsonConvert.SerializeObject(Student.students, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, studentJson);

                return Ok("Student data deleted and file updated.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while deleting student data: {ex.Message}");
            }
        }
    }
}
