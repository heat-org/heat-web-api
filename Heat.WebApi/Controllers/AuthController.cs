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

namespace Heat.WebApi.Controllers
{
    [Route("api/authenticate")]
    public class AuthController : Controller
    {
        private IConfiguration _config;
        private IUserService _services;

        public AuthController(IConfiguration config, IUserService service)
        {
            _config = config; _services = service;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Authenticate([FromBody]UsuarioVm a)
        {

            IActionResult response = BadRequest(ModelState);
            HttpContext.Items.Add("errorMessage", _config["ErrorMessages:Auth:00"]);


            if (ModelState.IsValid)
            {
                var user = _services.Login(a);
                if (user != null)
                {
                    response = Ok(new { token = CreateToken(user) });
                }
            }

            return response;
        }

        private string CreateToken(UsuarioVm user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email,user.CorreoElectronico),
                new Claim(JwtRegisteredClaimNames.Sub,user.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                // new Claim(JwtRegisteredClaimNames.Email, user.User.Email),
                // new Claim(JwtRegisteredClaimNames.Sub, user.Student.FullName),
                // new Claim(JwtRegisteredClaimNames..Jti, Guid.NewGuid().ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["JWT:Issuer"], _config["JWT:Issuer"], claims, expires: DateTime.Now.AddMinutes(45), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
