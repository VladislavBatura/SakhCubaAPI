using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SakhCubaAPI.Models.ViewModels;
using SakhCubaAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SakhCubaAPI.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(JWT_Users user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(user.Email);
            }

            var agent = await _authService.GetJWTUser(user.Email);
            if (agent is null || agent.Password != user.Password)
            {
                return Unauthorized(user.Email);
            }

            var json = _authService.CreateJSONWithClaims(agent);
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
                if (!await _authService.CreateJwtUser(user))
                    return BadRequest("Something went wrong with DB");
                return Ok();
            }
        }
    }
}
