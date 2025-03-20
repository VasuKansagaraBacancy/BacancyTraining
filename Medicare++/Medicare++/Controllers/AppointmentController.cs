using Medicare__.DTO;
using Medicare__.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicare__.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Receptionist")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentDTO dto)
        {
            var createdByUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (createdByUserIdClaim == null)
                return Unauthorized("Invalid user token.");

            string createdBy = createdByUserIdClaim.Value;
            var appointment = await _service.CreateAppointmentAsync(dto, createdBy);
            return Ok(appointment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentDTO dto)
        {
            var updatedByUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (updatedByUserIdClaim == null)
                return Unauthorized("Invalid user token.");

            string updatedBy = updatedByUserIdClaim.Value;
            var updatedAppointment = await _service.UpdateAppointmentAsync(id, dto, updatedBy);

            if (updatedAppointment == null)
                return NotFound($"Appointment with id {id} not found.");

            return Ok(updatedAppointment);
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetAppointmentDetailsById(int id)
        {
            var appointmentDetails = await _service.GetAppointmentDetailsByIdAsync(id);

            if (appointmentDetails == null)
                return NotFound($"No appointment details found for appointment ID {id}.");

            return Ok(appointmentDetails);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _service.GetAllAppointmentsAsync();
            return Ok(appointments);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAppointmentAsync(id);

            if (!deleted)
                return NotFound($"No appointment found with ID {id}.");

            return Ok($"Appointment with ID {id} has been deleted and the patient has been notified.");
        }

    }
}