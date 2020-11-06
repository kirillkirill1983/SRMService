using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Business
{
    public class CustomerService : ICustomerBusiness
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> AddAsync(Customer customer)
        {
            var tabl = new Customer();
            tabl.Name = customer.Name;
            tabl.Phone = customer.Phone;
            var result = await _customerRepository.Add(tabl);
            return result ;
        }
    }
}
