using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Cars;
using ServiceStationApi.Domain;

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
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await _carService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(long id)
        {
            Car car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            await _carService.AddAsync(car);
            return Ok(car);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Car>> Put(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            await _carService.UpDateAsync(car);

            return Ok(car);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(long id)
        {
            var car = await _carService.DeleteAsync(id);
            return Ok(car);
        }

    }
}

