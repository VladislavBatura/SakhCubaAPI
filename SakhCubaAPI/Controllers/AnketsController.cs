using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Services;

namespace SakhCubaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnketsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly SakhCubaContext _context;
        private readonly ApplicationService _app;

        public AnketsController(ILogger<AnketsController> logger, SakhCubaContext context, ApplicationService app)
        {
            _logger = logger;
            _context = context;
            _app = app;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var news = _app.GetLastNewsAsync(3);
            if (news.Result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpGet("news")]
        public IActionResult News()
        {
            return Ok(_app.GetAllNewsAsync());
        }

        [HttpGet("news/{id?}")]
        public IActionResult NewsView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = _app.GetOneNewsAsync((int)id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        [HttpPost("application")]
        public IActionResult Application(Application application)
        {
            if (ModelState.IsValid)
            {
                var result = _app.SendApplicationAsync(application,
                    Request.HttpContext.Connection.RemoteIpAddress
                    .MapToIPv4()
                    .ToString());

                if (!result.Result)
                {
                    return BadRequest(application);
                }

                return Ok();
            }
            else
            {
                return BadRequest(application);
            }
        }
    }
}
