#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Services;

namespace SakhCubaAPI.Areas.Admin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _newsService;

        public NewsController(NewsService news)
        {
            _newsService = news;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            var data = await _newsService.GetAllNewsAsync();
            if (data == null || !data.Any())
                return NoContent();
            return Ok(data);
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _newsService.GetOneNewsAsync(id);
            if (news == null)
                return NotFound();
            return Ok(news);
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutNews(News news)
        {
            if (news == null)
                return BadRequest();

            if (!await _newsService.UpdateNewsAsync(news))
                return BadRequest(news);

            return Ok();
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<News> PostNews(News news)
        {
            _newsService.AddNewsAsync(news);
            return Ok();
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsAsync(int id)
        {
            if (!await _newsService.DeleteNewsAsync(id))
                return BadRequest();
            return Ok();
        }
    }
}
