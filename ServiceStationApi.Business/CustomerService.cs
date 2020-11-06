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

        public Task<bool> AddAsync(Customer customer)
        {//////Что делать тут  ????
            try
            {
                var obj = new Customer();
                obj.Name=Customer.
                return ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<bool> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
