using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Workers
{
    public interface IWorkerService
    {
        Task<bool> AddAsync(Worker worker);
        Task<List<Worker>> GetAllAsynk();
        Task<bool> UpDateAsync(Worker worker);
        Task<Worker> GetByIdAsync(long Id);
        Task<Worker> DeleteAsync(long Id);
    }
}
