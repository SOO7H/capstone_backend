using FirstApp.Models;
using FirstApp.Services;
using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // GET: api/<EmployeesController>
        [HttpGet("company/{cid}")]
        public ActionResult<List<Employee>> GetByCompany(string cid)
        {
            return employeeService.GetByCompany(cid);
        }
        [HttpGet("username/{username}")]
        public ActionResult<Employee> GetByUsername(string username)
        {
            return employeeService.GetByUsername(username);
        }
        [HttpPost("signin")]
        public ActionResult<Employee> Signin([FromBody] Employee employee)
        {
            var user = employeeService.Signin(employee);
            if (user == null)
            {
                return NotFound($"Wrong Credentials");
            }

            return user;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return employee;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employeeService.Create(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee employee)
        {
            
            var existingEmployee = employeeService.Get(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            employeeService.Update(id, employee);
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            employeeService.Remove(employee.Id);
            return Ok($"Employee with Id = {id} deleted");

        }
    }
}
