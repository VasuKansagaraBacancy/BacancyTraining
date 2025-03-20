using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Medicare__.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Receptionist")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDTO dto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var createdByUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (createdByUserIdClaim == null)
                return Unauthorized("Invalid user token.");

            string createdBy = createdByUserIdClaim.Value;

            var patient = await _service.CreatePatientAsync(dto, createdBy);
            return Ok(patient);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDTO dto)
        {
            var updatedByUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (updatedByUserIdClaim == null)
                return Unauthorized("Invalid user token.");

            string updatedBy = updatedByUserIdClaim.Value;

            var updatedPatient = await _service.UpdatePatientAsync(id, dto, updatedBy);
            if (updatedPatient == null)
                return NotFound($"Patient with ID {id} not found.");

            return Ok(updatedPatient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _service.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound($"Patient with ID {id} not found.");

            return Ok(patient);
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeletePatient(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid user token.");

            string deletedBy = userIdClaim.Value;

            var success = await _service.SoftDeletePatientAsync(id, deletedBy);
            if (!success)
                return NotFound($"Patient with ID {id} not found or already deleted.");

            return Ok($"Patient {id} soft deleted successfully.");
        }

        [HttpDelete("PermanentDelete/{id}")]
        public async Task<IActionResult> PermanentDeletePatient(int id)
        {
            var success = await _service.PermanentDeletePatientAsync(id);
            if (!success)
                return NotFound($"Patient with ID {id} not found.");

            return Ok($"Patient {id} permanently deleted.");
        }


    }
}
