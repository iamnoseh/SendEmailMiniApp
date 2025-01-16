using Domain.Entities.EmailDomains;
using Infrastructure.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _service;

        public SendEmailController(ISendEmailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] UserEmailOption emailDto)
        {
            if (emailDto == null)
            {
                return BadRequest("Email data is required.");
            }

            try
            {
                await _service.SendEmailAsync(emailDto);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
