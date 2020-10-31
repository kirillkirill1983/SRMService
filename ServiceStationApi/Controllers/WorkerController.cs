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
    public class WorkerController : ControllerBase
    {
        ApplicationContext db;
        public WorkerController(ApplicationContext context)
        {
            db = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> Get()
        {

            return await db.Workers.ToListAsync();
        }
        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> Get(int id)
        {
            Worker worker = await db.Workers.FirstOrDefaultAsync(x => x.Id == id);
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

            db.Workers.Add(worker);
            await db.SaveChangesAsync();
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
            if (!db.Worker.Any(x => x.Id == worker.Id))
            {
                return NotFound();
            }

            db.Update(worker);
            await db.SaveChangesAsync();
            return Ok(worker);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> Delete(int id)
        {
            Worker worker = db.Workers.FirstOrDefault(x => x.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            db.Workers.Remove(worker);
            await db.SaveChangesAsync();
            return Ok(worker);

        }
    }
}
