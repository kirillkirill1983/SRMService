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
    public class WorkController : ControllerBase
    {
        ApplicationContext db;
        public WorkController(ApplicationContext context)
        {
            db = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> Get()
        {

            return await db.Worker.ToListAsync();
        }
        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(int id)
        {
            Work work = await db.Worker.FirstOrDefaultAsync(x => x.Id == id);
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

            db.Worker.Add(work);
            await db.SaveChangesAsync();
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
            if (!db.Worker.Any(x => x.Id == work.Id))
            {
                return NotFound();
            }

            db.Update(work);
            await db.SaveChangesAsync();
            return Ok(work);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> Delete(int id)
        {
            Work work = db.Worker.FirstOrDefault(x => x.Id == id);
            if (work == null)
            {
                return NotFound();
            }
            db.Worker.Remove(work);
            await db.SaveChangesAsync();
            return Ok(work);

        }

    }
}
