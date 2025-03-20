using iTextSharp.text;
using iTextSharp.text.pdf;
using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace Medicare__.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IReportService _reportService;

        public AuthController(IAuthService authService, IReportService reportService)
        {
            _authService = authService;
            _reportService = reportService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var (accessToken, refreshToken) = await _authService.LoginAsync(request);
            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            var (accessToken, refreshToken) = await _authService.RefreshTokenAsync(request);
            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDTO request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _authService.LogoutAsync(userId);
            return Ok("Logout successful");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _authService.AllUsersAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("generate-pdf")]
        public async Task<IActionResult> GenerateUsersPdf()
        {
            try
            {
                var pdfBytes = await _reportService.GenerateUsersPdfAsync();
                return File(pdfBytes, "application/pdf", "Users_Report.pdf");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }

}