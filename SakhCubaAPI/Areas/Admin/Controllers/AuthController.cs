using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SakhCubaAPI.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SakhCubaContext _context;

        public AuthController(SakhCubaContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(JWT_Users user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(user.Email);
            }

            var agent = _context.Users.FirstOrDefault(i => i.Email == user.Email);
            if (agent is null || agent.Password != user.Password)
            {
                return Unauthorized(user.Email);
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha512));

            var js = new JWT_Token()
            {
                IdToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpiresIn = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)).ToString()
            };

            var json = JsonConvert.SerializeObject(js);
            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> Register(JWT_Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }
            else
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
