using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SakhCubaAPI.Models.DBModels;
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
        public IActionResult Get(int? id)
        {
            if (id is null)
                return BadRequest();
            var app = _adminService.GetApplication((int)id);
            if (app == null)
                return BadRequest();
            return Ok(app);
        }

        // PUT api/<AdminController>/
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Application app)
        {
            if (!await _adminService.UpdateApplication(app))
                return BadRequest(app);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!await _adminService.DeleteApplication(id))
                return BadRequest();
            return Ok();
        }
    }
}
