using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ApplicationContext db;
        public CarController(ApplicationContext contextCar)
        {
            db = contextCar;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await db.Cars.ToListAsync();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            Car car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                return NotFound();
            return new ObjectResult(car);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            db.Cars.Add(car);
            await db.SaveChangesAsync();
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
            if (!db.Cars.Any(x => x.Id == car.Id))
            {
                return NotFound();
            }

            db.Update(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return Ok(car);

        }
    }
}

