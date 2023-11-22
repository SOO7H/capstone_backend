using FirstApp.Models;
using FirstApp.Services;
using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService vendorService;

        public VendorsController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }
        [HttpGet("username/{username}")]
        public ActionResult<Vendor> GetByUsername(string username)
        {
            return vendorService.GetByUsername(username);
        }


        // GET: api/<VendorsController>
        [HttpGet]
        public ActionResult<List<Vendor>> Get()
        {
            return vendorService.Get();
        }

        [HttpGet("approved")]
        public ActionResult<List<Vendor>> GetApproved()
        {
            return vendorService.GetApproved();
        }

        [HttpGet("pending")]
        public ActionResult<List<Vendor>> GetApprovalPending()
        {
            return vendorService.GetApprovalPending();
        }

        [HttpGet("unassigned")]
        public ActionResult<List<Vendor>> GetUnassigned()
        {
            return vendorService.GetUnassigned();
        }


        // GET api/<VendorsController>/5
        [HttpGet("{id}")]
        public ActionResult<Vendor> Get(string id)
        {
            var vendor = vendorService.Get(id);
            if (vendor == null)
            {
                return NotFound($"Vendor with Id = {id} not found");
            }
            return vendor;
        }

        // POST api/<VendorsController>
        [HttpPost]
        public ActionResult<Vendor> Post([FromBody] Vendor vendor)
        {
            vendorService.Create(vendor);

            return CreatedAtAction(nameof(Get), new { id = vendor.Id }, vendor);
        }
        [HttpPost("signin")]
        public ActionResult<Vendor> Signin([FromBody] Vendor vendor)
        {
            var user = vendorService.Signin(vendor);
            if (user == null)
            {
                return NotFound($"Wrong Credentials");
            }

            return user;
        }

        // PUT api/<VendorsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Vendor vendor)
        {
            var existingVendor = vendorService.Get(id);
            if (existingVendor == null)
            {
                return NotFound($"Vendor with Id = {id} not found");
            }
            vendorService.Update(id, vendor);
            return NoContent();
        }

        // DELETE api/<VendorsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var vendor = vendorService.Get(id);
            if (vendor == null)
            {
                return NotFound($"Vendor with Id = {id} not found");
            }
            vendorService.Remove(vendor.Id);
            return Ok($"Vendor with Id = {id} deleted");

        }
    }
}
