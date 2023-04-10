using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizSystem.API.Extensions
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;
        private ApiUser user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(int.Parse(jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                ) ;

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.NationalCode)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = configuration.GetSection("Jwt").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret , SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(UserSignInDTO dto)
        {
            user = await userManager.FindByNameAsync(dto.NationalCode);

            return (user != null && await userManager.CheckPasswordAsync(user, dto.Password));
        }
    }
}
