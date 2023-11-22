using FirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellingCarsController : ControllerBase
    {
        private readonly ITravellingCarService travellingCarService;


        public TravellingCarsController(ITravellingCarService travellingCarService)
        {
            this.travellingCarService = travellingCarService;
        }
        // GET: api/<TravellingCarsController>
        [HttpGet("vendor/{vid}")]
        public ActionResult<List<TravellingCar>> GetByVendor(string vid)
        {
            return travellingCarService.GetTravellingCarsByVendor(vid);
        }
        [HttpGet("company/{cid}")]
        public ActionResult<List<TravellingCar>> GetByCompany(string cid)
        {
            return travellingCarService.GetTravellingCarsByCompany(cid);
        }


        // POST api/<TravellingCarsController>
        [HttpPost]
        public void Post([FromBody] TravellingCar travellingCar)
        {
            travellingCarService.Create(travellingCar);
        }

        

        // DELETE api/<TravellingCarsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            travellingCarService.Remove(id);
        }
    }
}
