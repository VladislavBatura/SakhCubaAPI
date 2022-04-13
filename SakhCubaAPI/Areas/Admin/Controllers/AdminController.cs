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
        public IActionResult Index()
        {
            var data = _adminService.GetApplicationsAsync();
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var app = _adminService.GetApplication(id);
            if (app == null)
                return BadRequest(app);
            return Ok(app);
        }

        // PUT api/<AdminController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Application app)
        {
            if (!_adminService.UpdateApplication(app).Result)
                return BadRequest(app);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_adminService.DeleteApplication(id).Result)
                return BadRequest();
            return Ok();
        }
    }
}
