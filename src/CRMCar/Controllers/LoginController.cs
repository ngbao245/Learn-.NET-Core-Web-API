using Azure.Core.Pipeline;
using CRMCar.Data;
using CRMCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRMCar.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        AppDbContext _context = new AppDbContext();

        IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails(UserModel model)
        {
            if (model != null)
            {
                var resultLoginCheck = _context.User.Where(_ => _.Account == model.Account && _.Password == model.Password).FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credential");
                }
                else
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", model.Id.ToString()),
                        new Claim("Name", model.Name),
                        new Claim("Account", model.Account),
                        new Claim("Email", model.Email),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    //model.VerificationToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(model);
                }
            }
            else
            {
                return BadRequest("No data");
            }
        }
    }
}
