using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Models;
using AuthApi.Repositories;
using AuthApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController(){ }

        [HttpPost("")]
        public IActionResult Login([FromBody] User model) 
        {
            var user = UserRepository.Get(model.Username,model.Password);
            if(user == null)
                return NotFound(new {message = "Usuario nao encontrado"});
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return Ok(new {
                user = user,
                token= token
            });
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetAuthorized()
        {
            return Ok(new {message = "autorizado"});
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "employee")]
        public IActionResult GetEmployee()
        {
            return Ok(new {message = "employee"});
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "manager")]
        public IActionResult GetManager()
        {
            return Ok(new {message = "manager"});
        }
    }
}
