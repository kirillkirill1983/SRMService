using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceStationApi.Business;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;

namespace ServiceStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            var customer = await _customerService.GetAllAsynс();
            
            return Ok(customer);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetID(long id)
        {
           var customer = await _customerService.GetByIdAsync(id);
          
            return Ok(customer);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Post([FromBody] CustomerDTO customerDTO)
        {

            await _customerService.UpDateAsync(customerDTO);
            
            return Ok(customerDTO);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<CustomerDTO>> Put(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }

            await _customerService.UpDateAsync(customerDTO);
           
            return Ok(customerDTO);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDTO>> Delete(long id)
        {
            var customer = await _customerService.DeleteAsync(id);
            return Ok(customer);
        }

    }

}  

