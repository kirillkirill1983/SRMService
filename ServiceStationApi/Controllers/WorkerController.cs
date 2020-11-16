using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Workers;
using ServiceStationApi.Domain;

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
        public async Task<ActionResult<IEnumerable<Worker>>> Get()
        {
            return await _workerService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> Get(long id)
        {
            Worker worker = await _workerService.GetByIdAsync(id);
            if (worker == null)
                return NotFound();
            return new ObjectResult(worker);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Worker>> Post(Worker worker)
        {
            if (worker == null)
            {
                return BadRequest();
            }

            await _workerService.AddAsync(worker);
            return Ok(worker);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Worker>> Put(Worker worker)
        {
            if (worker == null)
            {
                return BadRequest();
            }

            await _workerService.UpDateAsync(worker);

            return Ok(worker);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> Delete(long id)
        {
            var worker = await _workerService.DeleteAsync(id);
            return Ok(worker);
        }
    }
}
