using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuracion;
        public AuthController(IConfiguration configuration)
        {
            _configuracion = configuration;
        }

        // POST api/<AuthController>
        [HttpPost ("GETTOKEN")]
        public IActionResult Post([FromBody] LoginModel login)
        {
            var userIsValid = validUser(login);

            if(!userIsValid) { 
                return Unauthorized();
            }
            var token = GenerateJWT(login.UserName);
            return Ok(new {jwt = token});
        }

        private object GenerateJWT(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["Jwt:Key"]));
            var credentials= new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Name,"Albert Villasboa"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuracion["JWT:Issuer"],
                audience: _configuracion["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(320),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool validUser(LoginModel login) {
            return login.UserName=="admin" && login.Password=="admin";
        }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
