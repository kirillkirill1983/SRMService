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
    public class ServiceController : ControllerBase
    {
        ApplicationContext db;
        public ServiceController(ApplicationContext context)
        {
            db = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {

            return await db.Services.ToListAsync();
        }
        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            Service service = await db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
                return NotFound();
            return new ObjectResult(service);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            db.Services.Add(service);
            await db.SaveChangesAsync();
            return Ok(service);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Service>> Put(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            if (!db.Services.Any(x => x.Id == service.Id))
            {
                return NotFound();
            }

            db.Update(service);
            await db.SaveChangesAsync();
            return Ok(service);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            Service service = db.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return Ok(service);

        }
    }
}
