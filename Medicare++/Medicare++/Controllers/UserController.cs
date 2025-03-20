using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Medicare__.Models;
using Medicare__.Services;
using Medicare__.Model_DTO;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Medicare__.DatabaseContext;
using Microsoft.AspNetCore.Authorization; 

namespace Medicare__.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            var adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _userService.AddUserAsync(userDto, adminId);
            return Ok(result);
        }

        [HttpPost("reset-password-request")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] ResetRequest request)
        {
            var result = await _userService.RequestPasswordResetAsync(request.Email);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var result = await _userService.ResetPasswordAsync(model.Token, model.NewPassword);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _userService.SoftDeleteUserAsync(id, adminId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("permanentdelete/{id}")]
        public async Task<IActionResult> PermanentDelete(Guid id)
        {
            var result = await _userService.PermanentDeleteUserAsync(id);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto updatedDto)
        {
            var adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _userService.UpdateUserAsync(id, updatedDto, adminId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", error = ex.Message });
            }
        }
    }
}