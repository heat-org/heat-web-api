using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Heat.Application;
using Heat.Application.Users;
using Heat.WebApi.Helper;
using Microsoft.Extensions.Options;

namespace Heat.WebApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserService _services;
        private readonly AppSettings _appSettings;

        public AuthController(IConfiguration config, IUserService service, IOptions<AppSettings> appSettings)
        {
            _config = config;
            _services = service;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UsuarioVm a)
        {

            IActionResult response = BadRequest(ModelState);
            HttpContext.Items.Add("errorMessage", _config["ErrorMessages:Auth:00"]);


            if (ModelState.IsValid)
            {
                var user = await _services.Login(a);
                if (user != null)
                {
                    var dto = new TokenDTO();
                    dto.Token = GenerateJwtToken(user);
                    dto.FullName = $"{user.Nombre} {user.Apellido}";
                    dto.Sex = user.Sexo;
                    dto.Phone = user.Telefono;
                    dto.Email = user.CorreoElectronico;

                    response = Ok(dto);
                }
            }

            return response;
        }
        private string GenerateJwtToken(UsuarioVm userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.CorreoElectronico),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddYears(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
