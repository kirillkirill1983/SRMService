using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Workers;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> Get()
        {
            var worker = await _workerService.GetAllAsynk();
            return Ok(worker);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDTO>> GetID(long id)
        {
            var worker = await _workerService.GetByIdAsync(id);
            return Ok(worker);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<WorkerDTO>> Post([FromBody] WorkerDTO workerDTO)
        {

            await _workerService.UpDateAsync(workerDTO);
            return Ok(workerDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<WorkerDTO>> Put(WorkerDTO workerDTO)
        {
            if (workerDTO == null)
            {
                return BadRequest();
            }

            await _workerService.UpDateAsync(workerDTO);

            return Ok(workerDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerDTO>> Delete(long id)
        {
            var worker = await _workerService.DeleteAsync(id);
            return Ok(worker);
        }
    }
}
