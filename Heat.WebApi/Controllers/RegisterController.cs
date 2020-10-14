using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heat.Application.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private IConfiguration _config;
        private IUserService _services;


        public RegisterController(IConfiguration config, IUserService service)
        {
            _config = config; _services = service;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UsuarioVm usuario)
        {
            return Ok(await _services.RegisterAsync(usuario));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}
