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
    public class CustomerController : ControllerBase
    {
        ApplicationContext db;
        public CustomerController(ApplicationContext context)
        {
            db = context;
            if (!db.Customers.Any())
            {
                db.Customers.Add(new Customer { Name = "Tom", Phone = "05050505" });

                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await db.Customers.ToListAsync();
        }



        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            Customer customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();
            return new ObjectResult(customer);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!db.Customers.Any(x => x.Id == customer.Id))
            {
                return NotFound();
            }

            db.Update(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return Ok(customer);

        }
    }

}

