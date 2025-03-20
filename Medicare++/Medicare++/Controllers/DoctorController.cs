using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicare__.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorCreateDTO doctorDTO)
        {
            try
            {
                var createdByUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (createdByUserIdClaim == null)
                    return Unauthorized("Invalid user token.");

                string createdByUserId = createdByUserIdClaim.Value;

                Doctor newDoctor = await _doctorService.AddDoctorAsync(doctorDTO, createdByUserId);

                return Ok(new
                {
                    Message = "Doctor created successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();

                if (doctors == null || !doctors.Any())
                {
                    return NotFound(new { Message = "No doctors found." });
                }

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred. Please try again later." });
            }
        }
        [HttpPut("UpdateDoctor/{doctorId}")]
        public async Task<IActionResult> UpdateDoctorAsync(int doctorId, [FromBody] DoctorUpdateDTO doctorDto)
        {
            if (doctorDto == null || doctorId <= 0)
            {
                return BadRequest(new { Message = "Invalid doctor data." });
            }

            try
            {
                var result = await _doctorService.UpdateDoctorAsync(doctorId, doctorDto);

                if (!result)
                {
                    return NotFound(new { Message = $"Doctor with ID {doctorId} not found." });
                }
                return Ok(new { Message = "Doctor updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred. Please try again later." });
            }
        }
        [HttpDelete("SoftDeleteDoctor/{doctorId}")]
        public async Task<IActionResult> SoftDeleteDoctorAsync(int doctorId)
        {
            if (doctorId <= 0)
                return BadRequest(new { Message = "Invalid DoctorId." });

            try
            {
                var deleted = await _doctorService.SoftDeleteDoctorAsync(doctorId);

                if (!deleted)
                    return NotFound(new { Message = $"Doctor with ID {doctorId} not found or already deleted." });

                return Ok(new { Message = $"Doctor with ID {doctorId} has been soft deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }

        [HttpDelete("PermanentDeleteDoctor/{doctorId}")]
        public async Task<IActionResult> PermanentDeleteDoctorAsync(int doctorId)
        {
            if (doctorId <= 0)
                return BadRequest(new { Message = "Invalid DoctorId." });

            try
            {
                var deleted = await _doctorService.PermanentDeleteDoctorAsync(doctorId);

                if (!deleted)
                    return NotFound(new { Message = $"Doctor with ID {doctorId} not found." });

                return Ok(new { Message = $"Doctor with ID {doctorId} has been permanently deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
    }
}
