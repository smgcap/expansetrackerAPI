using expansetrackerAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace expansetrackerAPI.Data.Repo
{
    public class JwtService:IJwtService
    {
        public readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            //var claims = new List<Claim>{
            //    new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //    new(JwtRegisteredClaimNames.Email,request.Email),
            //    new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //};
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                Issuer = "your-issuer",
                Audience = "your-audience",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
