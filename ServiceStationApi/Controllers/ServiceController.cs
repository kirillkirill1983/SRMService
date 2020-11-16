using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Services;
using ServiceStationApi.Domain;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiseService _serviseService;
        public ServiceController(IServiseService serviseService)
        {
            _serviseService = serviseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return await _serviseService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(long id)
        {
            Service service = await _serviseService.GetByIdAsync(id);
            if (service == null)
                return NotFound();
            return new ObjectResult(service);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            await _serviseService.AddAsync(service);
            return Ok(service);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Service>> Put(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            await _serviseService.UpDateAsync(service);

            return Ok(service);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(long id)
        {
            var service = await _serviseService.DeleteAsync(id);
            return Ok(service);
        }
    }
}
