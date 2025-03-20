using Medicare__.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicare__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specializations = await _specializationService.GetAllSpecializationsAsync();
            return Ok(specializations);  
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var specialization = await _specializationService.GetByIdWithDoctorsAsync(id);

            if (specialization == null)
                return NotFound("Specialization not found.");

            return Ok(specialization);  
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Specialization name is required.");

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid user token.");

            string createdBy = userIdClaim.Value;

            var specialization = await _specializationService.CreateSpecializationAsync(name, createdBy);

            return Ok("Specialization created successfully.");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Specialization name is required.");

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid user token.");

            string updatedBy = userIdClaim.Value;

            var result = await _specializationService.UpdateSpecializationAsync(id,name, updatedBy);

            if (!result)
                return NotFound("Specialization not found.");

            return Ok("Specialization updated successfully.");
        }

        [Authorize(Roles = "Admin")]    
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _specializationService.DeleteSpecializationAsync(id);
            

            return Ok("Specialization permanently deleted.");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{doctorId}/assign-specialization/{specializationId}")]
        public async Task<IActionResult> AssignSpecialization(int doctorId, int specializationId)
        {
            if (doctorId <= 0 || specializationId <= 0)
                return BadRequest("Doctor ID and Specialization ID must be greater than zero.");

            var result = await _specializationService.AssignSpecializationAsync(doctorId, specializationId);

            if (!result)
                return NotFound("Either the Doctor does not exist, is deleted, or the Specialization is invalid.");

            return Ok($"Specialization (ID: {specializationId}) assigned to Doctor (ID: {doctorId}) successfully.");
        }

    }

}
