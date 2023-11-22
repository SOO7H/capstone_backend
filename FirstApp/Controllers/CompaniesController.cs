using FirstApp.Models;
using FirstApp.Services;
using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        [HttpGet("username/{username}")]
        public ActionResult<Company> GetByUsername(string username)
        {
            return companyService.GetByUsername(username);
        }


        // GET: api/<CompaniesController>
        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            return companyService.Get();
        }

        [HttpGet("approved")]
        public ActionResult<List<Company>> GetApproved()
        {
            return companyService.GetApproved();
        }

        [HttpGet("pending")]
        public ActionResult<List<Company>> GetApprovalPending()
        {
            return companyService.GetApprovalPending();
        }

        [HttpGet("unassigned")]
        public ActionResult<List<Company>> GetUnassigned()
        {
            return companyService.GetUnassigned();
        }


        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public ActionResult<Company> Get(string id)
        {
            var company = companyService.Get(id);
            if (company == null)
            {
                return NotFound($"Company with Id = {id} not found");
            }
            return company;
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public ActionResult<Company> Post([FromBody] Company company)
        {
            companyService.Create(company);

            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }

        [HttpPost("signin")]
        public ActionResult<Company> Signin([FromBody] Company company)
        {
            var user = companyService.Signin(company);
            if (user == null)
            {
                return NotFound($"Wrong Credentials");
            }

            return user;
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Company company)
        {
            var existingCompany = companyService.Get(id);
            if (existingCompany == null)
            {
                return NotFound($"Company with Id = {id} not found");
            }
            companyService.Update(id, company);
            return NoContent();
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var company = companyService.Get(id);
            if (company == null)
            {
                return NotFound($"Company with Id = {id} not found");
            }
            companyService.Remove(company.Id);
            return Ok($"Company with Id = {id} deleted");

        }
    }
}