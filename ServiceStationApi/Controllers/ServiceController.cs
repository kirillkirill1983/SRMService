using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Services;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

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
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> Get()
        {
            var detail = await _serviseService.GetAllAsynk();

            return Ok(detail);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetID(long id)
        {
            var detail = await _serviseService.GetByIdAsync(id);

            return Ok(detail);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> Post([FromBody] ServiceDTO serviceDTO)
        {

            await _serviseService.UpDateAsync(serviceDTO);

            return Ok(serviceDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<ServiceDTO>> Put(ServiceDTO serviceDTO)
        {
            if (serviceDTO == null)
            {
                return BadRequest();
            }

            await _serviseService.UpDateAsync(serviceDTO);

            return Ok(serviceDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceDTO>> Delete(long id)
        {
            var detail = await _serviseService.DeleteAsync(id);
            return Ok(detail);
        }
    }
}

