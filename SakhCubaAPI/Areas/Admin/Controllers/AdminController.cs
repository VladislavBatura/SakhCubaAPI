using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SakhCubaAPI.Models.ViewModels;
using SakhCubaAPI.Services;

namespace SakhCubaAPI.Areas.Admin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _adminService.GetApplicationsAsync();
            if (data == null || !data.Any())
                return NoContent();

            return Ok(data);
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null)
                return BadRequest();

            var app = await _adminService.GetApplicationAsync((int)id);
            if (app == null)
                return BadRequest();

            return Ok(app);
        }

        // PUT api/<AdminController>/
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ApplicationViewModel app)
        {
            if (!await _adminService.UpdateApplicationAsync(app))
                return BadRequest(app);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!await _adminService.DeleteApplicationAsync(id))
                return BadRequest();
            return Ok();
        }
    }
}
