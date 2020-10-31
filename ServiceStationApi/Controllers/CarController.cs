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
        ApplicationContext dCar;
        public CarController(ApplicationContext contextCar)
        {
            dCar = contextCar;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await dCar.Cars.ToListAsync();
        }
    }
}

