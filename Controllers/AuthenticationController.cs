using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using WebProject.Services;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService service;
        public AuthenticationController(IAuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] AuthenticationData data)
        {
            var response = service.Login(data);
            if (!string.IsNullOrEmpty(response.Jwt)) {
                return Ok(response);
            }

            return Unauthorized();
        }
    }
}
