using FirstApp.Services;
using FirstApp.Models;
using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET api/<Admin>/5
        [HttpGet("{id}")]
        public ActionResult<Admin> Get(string id)
        {
            return adminService.Get(id);
        }
        [HttpPost("signin")]
        public ActionResult<Admin> Signin([FromBody] Admin admin)
        {
            var user = adminService.Signin(admin);
            if (user == null)
            {
                return NotFound($"Wrong Credentials");
            }

            return user;
        }

        [HttpGet("username/{username}")]
        public ActionResult<Admin> GetByUsername(string username)
        {
            return adminService.GetByUsername(username);
        }
        [HttpPost]
        public ActionResult<Admin> Post([FromBody] Admin admin)
        {
            adminService.Create(admin);

            return CreatedAtAction(nameof(Get), new { id = admin.Id }, admin);
        }

    }
}
