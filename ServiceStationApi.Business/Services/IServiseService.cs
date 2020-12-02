using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Services
{
    public interface IServiseService
    {
        Task<bool> AddAsync(ServiceDTO serviceDTO);
        Task<List<ServiceDTO>> GetAllAsynk();
        Task<bool> UpDateAsync(ServiceDTO serviceDTO);
        Task<ServiceDTO> GetByIdAsync(long Id);
        Task<ServiceDTO> DeleteAsync(long Id);
    }
}
