using CRMCar.Entity;
using CRMCar.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public ResponseLoginModel RefreshToken(string refreshToken)
        {
            //var validateToken = token

            //var user = get user từ db
            var user = new User()
            {
                Name = "ABC",
                Id = 1,
            };

            var jwtToken = CreateJwtToken(user);
            var newRefreshToken = CreateRefreshToken(user);
            var result = new ResponseLoginModel
            {
                FullName = user.Name,
                UserId = user.Id,
                Token = jwtToken,
                RefreshToken = newRefreshToken.Token,
            };
            return result;
        }

        public void Register(RequestRegisterModel model)
        {
            // kiểm tra acc đã exist chưa

            var verifyToken = "123456"; // viết function tạo OTP (chuỗi gồm 6 số random)

            // add database
            //send email


        }
        public void VerifyẸmail() //otp, userId (define Request VerifyEmailModel)
        {
            // kiểm tra otp đã đúng chưa
            // update database
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
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim(ClaimTypes.Email, "aaaaaa"),
                    //new Claim(ClaimTypes.Role, "Manager"),
                    new Claim("CarNumber", "1"),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credential,
                Audience = "",
                Issuer = "",
            };
            var token = tokenHanler.CreateToken(tokenDescription);
            return tokenHanler.WriteToken(token);
        }
    }
}
