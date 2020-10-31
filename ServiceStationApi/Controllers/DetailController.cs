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
    public class DetailController : ControllerBase
    {
        ApplicationContext db;
        public DetailController(ApplicationContext context)
        {
            db = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> Get()
        { 
        
            return await db.Details.ToListAsync();
        }
         // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> Get(int id)
        {
            Detail detail = await db.Details.FirstOrDefaultAsync(x => x.Id == id);
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

            db.Details.Add(detail);
            await db.SaveChangesAsync();
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
            if (!db.Details.Any(x => x.Id == detail.Id))
            {
                return NotFound();
            }

            db.Update(detail);
            await db.SaveChangesAsync();
            return Ok(detail);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detail>> Delete(int id)
        {
            Detail detail = db.Details.FirstOrDefault(x => x.Id == id);
            if (detail == null)
            {
                return NotFound();
            }
            db.Details.Remove(detail);
            await db.SaveChangesAsync();
            return Ok(detail);

        }
    }
}
