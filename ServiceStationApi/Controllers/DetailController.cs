using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Details;
using ServiceStationApi.Domain;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService _detailService;
        public DetailController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> Get()
        {
            return await _detailService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> Get(long id)
        {
            Detail detail = await _detailService.GetByIdAsync(id);
            if (detail == null)
                return NotFound();
            return new ObjectResult(detail);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Detail>> Post(Detail detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }

            await _detailService.AddAsync(detail);
            return Ok(detail);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Detail>> Put(Detail detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }

            await _detailService.UpDateAsync(detail);

            return Ok(detail);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detail>> Delete(long id)
        {
            var detail = await _detailService.DeleteAsync(id);
            return Ok(detail);
        }

    }
}
