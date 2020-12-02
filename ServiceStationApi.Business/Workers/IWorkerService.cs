using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Workers
{
    public interface IWorkerService
    {
        Task<bool> AddAsync(WorkerDTO workerDTO);
        Task<List<WorkerDTO>> GetAllAsynk();
        Task<bool> UpDateAsync(WorkerDTO workerDTO);
        Task<WorkerDTO> GetByIdAsync(long Id);
        Task<WorkerDTO> DeleteAsync(long Id);
    }
}
