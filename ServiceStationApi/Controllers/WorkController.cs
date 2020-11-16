using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Works;
using ServiceStationApi.Domain;

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
        public async Task<ActionResult<IEnumerable<Work>>> Get()
        {
            return await _workService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(long id)
        {
            Work work = await _workService.GetByIdAsync(id);
            if (work == null)
                return NotFound();
            return new ObjectResult(work);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Work>> Post(Work work)
        {
            if (work == null)
            {
                return BadRequest();
            }

            await _workService.AddAsync(work);
            return Ok(work);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Work>> Put(Work work)
        {
            if (work == null)
            {
                return BadRequest();
            }

            await _workService.UpDateAsync(work);

            return Ok(work);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> Delete(long id)
        {
            var work = await _workService.DeleteAsync(id);
            return Ok(work);
        }
    }
}
