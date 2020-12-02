using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Works
{
    public interface IWorkService
    {
        Task<bool> AddAsync (WorkDTO workDTO);
        Task<List<WorkDTO>> GetAllAsynk();
        Task<bool> UpDateAsync(WorkDTO workDTO);
        Task<WorkDTO> GetByIdAsync(long Id);
        Task<WorkDTO> DeleteAsync(long Id);
    }
}
