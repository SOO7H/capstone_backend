using FirstApp.Models;
using FirstApp.Services;
using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;


        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }
        // GET: api/<CarsController>
        [HttpGet("vendor/{vid}")]
        public ActionResult<List<Car>> GetByVendor(string vid)
        {
            return carService.GetByVendor(vid);
        }
        [HttpGet("available")]
        public ActionResult<List<Car>> GetAvailable()
        {
            return carService.GetAvailable();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(string id)
        {
            return carService.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            carService.Create(car);

            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Car car)
        {

            carService.Update(id, car);
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            
            carService.Remove(id);
            return Ok($"Car with Id = {id} deleted");

        }
    }
}