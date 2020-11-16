using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Services
{
   public interface IServiceRepository

    {
        Task<bool> Add(Service service);
        Task<bool> Update(Service service);
        Task<List<Service>> GetAll();
        Task<Service> Delete(long Id);
        Task<Service> GetById(long Id);
    }

}
