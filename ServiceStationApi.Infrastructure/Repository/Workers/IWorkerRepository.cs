using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Workers
{
    public interface IWorkerRepository
    {
        Task<bool> Add(Worker worker);
        Task<bool> Update(Worker worker);
        Task<List<Worker>> GetAll();
        Task<Worker> Delete(long Id);
        Task<Worker> GetById(long Id);
    }
}
