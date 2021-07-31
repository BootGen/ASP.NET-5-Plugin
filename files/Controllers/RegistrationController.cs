using Microsoft.AspNetCore.Mvc;
using WebProject.Services;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("registration")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService service;
        public RegistrationController(IRegistrationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegistrationData data)
        {
            return Ok(service.Register(data));
        }
    }
}
