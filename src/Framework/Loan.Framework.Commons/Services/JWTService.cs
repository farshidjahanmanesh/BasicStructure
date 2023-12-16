using Loan.Framework.Commons.Contracts;
using Loan.Framework.Commons.Dtos.JWTService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Loan.Framework.Commons.Services
{
    public class JWTService : IJWTService
    {
        private readonly string jwtKey;

        public JWTService(string jwtKey)
        {
            this.jwtKey = jwtKey;
        }
        public async Task<GetTokenOutputDto> GetToken(GetTokenInputDto inputModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(inputModel.Claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new GetTokenOutputDto(tokenHandler.WriteToken(token));
        }
    }
}
