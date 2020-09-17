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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Heat.WebApi.Controllers
{
    [Route("api/authenticate")]
    public class AuthController : Controller
    {
        private IConfiguration _config;
        private IUserService _service;

        public AuthController(IConfiguration config, IUserService service)
        {
            _config = config; _service = service;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Authenticate(User user)
        {

            IActionResult response = BadRequest(ModelState);
            HttpContext.Items.Add("errorMessage", _config["ErrorMessages:Auth:00"]);


            if (ModelState.IsValid)
            {
				//var user = (UserLoginViewModel)_service.Login(login).ResultObject;
				if (user != null)
				{
					response = Ok(new { token = CreateToken(user) });
				}
            }

            return response;
        }

        private string CreateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.FirstName),
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
