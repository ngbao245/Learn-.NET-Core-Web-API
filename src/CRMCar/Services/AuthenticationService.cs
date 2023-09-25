using CRMCar.Entity;
using CRMCar.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CRMCar.Services
{
    public interface IAuthenticationService
    {
        ResponseLoginModel Authenticator(RequestLoginModel model);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string Key = "gj6ghgowrhg949gjgofksnk3frmkf";
        public AuthenticationService()
        {

        }

        public ResponseLoginModel Authenticator(RequestLoginModel model)
        {
            //var account = model. 
            //if (account == null)
            //{

            //}
            var account = new User()
            {
                Name = "ABC",
                Id = 1,

            };

            var token = CreateJwtToken(account);
            var refreshToken = CreateRefreshToken(account);
            var result = new ResponseLoginModel
            {
                FullName = account.Name,
                UserId = account.Id,
                Token = token,
                RefreshToken = refreshToken.Token,
            };
            return result;
        }

        private RefreshTokens CreateRefreshToken(User account)
        {
            var randomByte = new Byte[64];
            var token = Convert.ToBase64String(randomByte);
            var refreshToken = new RefreshTokens
            {
                UserId = account.Id,
                ExpireTime = DateTime.Now.AddDays(1),
                isActive = true,
                Token = token,
            };
            //add refresh token vào db
            return refreshToken;
        }

        private string CreateJwtToken(User account)
        {
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Key);
            var securityKey = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Audience = "",
                Issuer = "",
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim(ClaimTypes.Email, "aaaaaa"),
                    new Claim("CarNumber", "1"),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credential,
            };
            var token = tokenHanler.CreateToken(tokenDescription);
            return tokenHanler.WriteToken(token);
        }
    }
}
