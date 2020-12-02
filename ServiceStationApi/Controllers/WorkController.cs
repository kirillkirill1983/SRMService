using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Works;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkDTO>>> Get()
        {
            var detail = await _workService.GetAllAsynk();

            return Ok(detail);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkDTO>> GetID(long id)
        {
            var detail = await _workService.GetByIdAsync(id);

            return Ok(detail);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<WorkDTO>> Post([FromBody] WorkDTO workDTO)
        {
            await _workService.UpDateAsync(workDTO);
            return Ok(workDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<WorkDTO>> Put(WorkDTO workDTO)
        {
            if (workDTO == null)
            {
                return BadRequest();
            }

            await _workService.UpDateAsync(workDTO);

            return Ok(workDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkDTO>> Delete(long id)
        {
            var work = await _workService.DeleteAsync(id);
            return Ok(work);
        }
    }
}
