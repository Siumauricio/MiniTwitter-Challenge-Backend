using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mini.Twitter.Models;
using Mini.Twitter.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mini.Twitter.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller {

        private readonly ILoginRepository _loginRepository;

        public AuthController(ILoginRepository loginRepository) {
            this._loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel user) {
            if (user == null) {
                return Ok(false);
            }
            var result = await _loginRepository.Login(user);
            if (result!=null) {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString,IdUser = result.IdUser });
         }
            return Unauthorized();
        }
    }
}
