using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day4.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public ActionResult<string> RegisterStudent([FromBody] Student request)
        {
            var data = _studentService.Register(request.Name, request.Age);
            return Ok(new { Message = data });
        }
    }
}
