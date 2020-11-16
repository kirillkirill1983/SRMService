using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Services
{
    public interface IServiseService
    {
        Task<bool> AddAsync(Service service);
        Task<List<Service>> GetAllAsynk();
        Task<bool> UpDateAsync(Service service);
        Task<Service> GetByIdAsync(long Id);
        Task<Service> DeleteAsync(long Id);
    }
}
