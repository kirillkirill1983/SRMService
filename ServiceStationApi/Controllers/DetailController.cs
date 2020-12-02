using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business.Details;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService _detailService;

        public DetailController(IDetailService carService)
        {
            _detailService = carService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailDTO>>> Get()
        {
            var detail = await _detailService.GetAllAsynk();

            return Ok(detail);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailDTO>> GetID(long id)
        {
            var detail = await _detailService.GetByIdAsync(id);

            return Ok(detail);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<DetailDTO>> Post([FromBody] DetailDTO detailDTO)
        {

            await _detailService.UpDateAsync(detailDTO);

            return Ok(detailDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<DetailDTO>> Put(DetailDTO detailDTO)
        {
            if (detailDTO == null)
            {
                return BadRequest();
            }

            await _detailService.UpDateAsync(detailDTO);

            return Ok(detailDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailDTO>> Delete(long id)
        {
            var detail = await _detailService.DeleteAsync(id);
            return Ok(detail);
        }
    }
}
