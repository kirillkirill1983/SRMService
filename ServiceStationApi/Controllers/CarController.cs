using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Cars;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        
        public CarController(ICarService carService)
        {
            _carService = carService;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> Get()
        {
            var car = await _carService.GetAllAsynk();

            return Ok(car);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetID(long id)
        {
            var customer = await _carService.GetByIdAsync(id);

            return Ok(customer);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<CarDTO>> Post([FromBody] CarDTO carDTO)
        {

            await _carService.UpDateAsync(carDTO);

            return Ok(carDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<CarDTO>> Put(CarDTO carDTO)
        {
            if (carDTO == null)
            {
                return BadRequest();
            }

            await _carService.UpDateAsync(carDTO);

            return Ok(carDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDTO>> Delete(long id)
        {
            var car = await _carService.DeleteAsync(id);
            return Ok(car);
        }
    }
}

