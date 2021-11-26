using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mini.Twitter.Models;
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
    public class AuthController : ControllerBase {

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user) {
            if (user == null) {
                return Ok(false);
            }
            if (user.Username == "Hola" && user.password == "123") {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecret@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken {
                    Issuer:"http://localhost:4200",
                    //Claims = new List<Claim>(),
                    //SigningCredentials = signinCredentials,
                    //issu
                    //expires
                }
            }
        }
    }
}
