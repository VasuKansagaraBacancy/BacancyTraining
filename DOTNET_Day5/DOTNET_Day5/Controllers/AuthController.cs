using DOTNET_Day5;
using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService; 
    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest(new { Message = "Invalid request. Username and password are required." });
        }
        if (model.Username == "vasu" && model.Password == "vasu123")
        {
            var token = _jwtService.GenerateToken(model.Username);
            return Ok(new { Token = token });
        }
        return Unauthorized(new { Message = "Invalid username or password." });
    }
}