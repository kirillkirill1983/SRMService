using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationApi.Business
{
     public interface ICustomerService
    {
        Task<bool> AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsynk();
        Task<bool> UpDateAsync(Customer customer);
        Task<Customer> GetByIdAsync(long Id);
        Task<bool> DeleteAsync(long Id);
    }
}
