using Heat.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private IUserService _services;

        public RegisterController(IConfiguration config, IUserService service)
        {
            _services = service;
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UsuarioVm usuario)
        {
            var newUser = await _services.RegisterAsync(usuario);
            return Ok(newUser);
        }
    }
}