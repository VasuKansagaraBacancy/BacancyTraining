using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medicare__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IReceptionistService _service;

        public ReceptionistsController(IReceptionistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var receptionists = await _service.GetAllReceptionistsAsync();
            return Ok(receptionists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receptionist = await _service.GetReceptionistByIdAsync(id);
            if (receptionist == null)
                return NotFound("Receptionist not found.");

            return Ok(receptionist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReceptionistDTO receptionistDTO)
        {
            try
            {
                var createdReceptionist = await _service.CreateReceptionistAsync(receptionistDTO);
                return Ok("Receptionist created successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReceptionistDTO receptionistDTO)
        {
            var receptionist = await _service.GetReceptionistByIdAsync(id);
            if (receptionist==null)
                return NotFound("Receptionist not found.");

            var updated = await _service.UpdateReceptionistAsync(id,receptionistDTO);        

            return Ok("Receptionist updated successfully.");
        }

        [HttpDelete("SoftDeleteReceptionist/{receptionistId}")]
        public async Task<IActionResult> SoftDeleteReceptionistAsync(int receptionistId)
        {
            if (receptionistId <= 0)
                return BadRequest(new { Message = "Invalid ReceptionistId." });

            try
            {
                var deleted = await _service.SoftDeleteReceptionistAsync(receptionistId);

                if (!deleted)
                    return NotFound(new { Message = $"Receptionist with ID {receptionistId} not found or already deleted." });

                return Ok(new { Message = $"Receptionist with ID {receptionistId} has been soft deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }

        [HttpDelete("PermanentDeleteReceptionist/{receptionistId}")]
        public async Task<IActionResult> HardDeleteReceptionAsync(int receptionistId)
        {
            if (receptionistId <= 0)
                return BadRequest(new { Message = "Invalid ReceptionistId." });

            try
            {
                var deleted = await _service.PermanentDeleteReceptionistAsync(receptionistId);

                if (!deleted)
                    return NotFound(new { Message = $"Receptionist with ID {receptionistId} not found." });

                return Ok(new { Message = $"Receptionist with ID {receptionistId} has been permanently deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
    }
}