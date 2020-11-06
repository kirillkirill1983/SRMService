using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            };
        }

        public Task<bool> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
