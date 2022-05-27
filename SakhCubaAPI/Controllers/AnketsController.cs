using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Models.ViewModels;
using SakhCubaAPI.Services;

namespace SakhCubaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnketsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ApplicationService _app;

        public AnketsController(ILogger<AnketsController> logger, SakhCubaContext context, ApplicationService app)
        {
            _logger = logger;
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var news = await _app.GetLastNewsAsync(3);
            if (news is null || !news.Any())
                return NoContent();

            return Ok(news);
        }

        [HttpGet("news")]
        public async Task<IActionResult> News()
        {
            var news = await _app.GetAllNewsAsync();
            if (news is null || !news.Any())
                return NoContent();

            return Ok(news);
        }

        [HttpGet("news/{id?}")]
        public async Task<IActionResult> NewsView(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var news = await _app.GetOneNewsAsync((int)id);
            if (news is null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        [HttpPost("application")]
        public async Task<IActionResult> Application([FromBody]ApplicationViewModel application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(application);
            }
            else
            {
                _logger.LogInformation("Model is ok");
                var result = await _app.SendApplicationAsync(application,
                    Request.HttpContext.Connection.RemoteIpAddress
                    .MapToIPv4()
                    .ToString());

                if (!result)
                {
                    _logger.LogError("Can't add model to db");
                    return BadRequest(application);
                }

                _logger.LogInformation("Everything is ok");
                return Ok();
            }
        }
    }
}
