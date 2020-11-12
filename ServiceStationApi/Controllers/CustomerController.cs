using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Business;
using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure;


namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _customerService.GetAllAsynk();
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(long id)
        {
            Customer customer = await _customerService.GetByIdAsync(id);
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

            await _customerService.AddAsync(customer);
            //return RedirectToAction(nameof(Index))
            
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

            await _customerService.UpDateAsync(customer);
           
            return Ok(customer);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var customer = await _customerService.DeleteAsync(id);
            return Ok(customer);
        }

        #region
        //private readonly ICustomerService _customerService;

        //public CustomerController(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}

        //[HttpGet("{Index}")]
        ////get:CUSTOMER
        // public async Task<ActionResult<IEnumerable<Customer>>> Index()
        //{
        //    return await _customerService.GetAllAsynk();

        //}
        ////public async Task<IActionResult> Index()
        ////{
        ////    return View(await _customerService.GetAllAsynk());
        ////}
        //[HttpGet("{id}")]
        ////get ::customer /Details/id
        //public async Task<IActionResult> Details(long? Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }
        //    var customer = await _customerService.GetByIdAsync(Id.Value);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}

        ////GET::Customer/creat
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST: Customer/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Phone,Cars")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _customerService.AddAsync(customer);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}
        /////get: Customer/Edit/Id
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var customer = await _customerService.GetByIdAsync(id.Value);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}

        ////POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long Id, [Bind("Id,Name,Phone,Cars")] Customer customer)
        //{
        //    if (Id!=customer.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        await _customerService.UpDateAsync(customer);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _customerService.GetByIdAsync(id.Value);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var user = await _customerService.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion
    }

}  

