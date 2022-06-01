using Contracts.Interfaces;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SakhCubaAPI.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SakhCubaAPI.Services
{
    public class AuthService
    {
        private readonly IRepositoryWrapper _repository;

        public AuthService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<JWT_Users> GetJWTUser(string email)
        {
            return await _repository.JWTUser.GetJWTUsersByEmailAsync(email);
        }

        public async Task<bool> CreateJwtUser(JWT_Users jwtUser)
        {
            if (jwtUser is null)
                return false;

            _repository.JWTUser.CreateJWTUsers(jwtUser);
            await _repository.SaveAsync();
            return true;
        }

        public string CreateJSONWithClaims(JWT_Users user)
        {
            var claims = CreateClaims(user.Email);
            var jwtToken = CreateJwtToken(claims);

            var jwtToJson = new JWT_Token()
            {
                IdToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpiresIn = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)).ToString()
            };

            return JsonConvert.SerializeObject(jwtToJson);
        }

        private List<Claim> CreateClaims(string email)
        {
            return new List<Claim> { new Claim(ClaimTypes.Email, email) };
        }

        private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha512));
        }
    }
}
