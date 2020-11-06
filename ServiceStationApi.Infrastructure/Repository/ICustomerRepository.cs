using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository
{
     public interface ICustomerRepository
    {
        Task<bool> Add(Customer customer);
        Task<bool> Update(Customer customer);
        Task<List<Customer>> GetAll();
        Task<bool> Delete (long Id);
    }
}
