using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Details
{
    public interface IDetailService
    {
        Task<bool> AddAsync(DetailDTO detailDTO);
        Task<List<DetailDTO>> GetAllAsynk();
        Task<bool> UpDateAsync(DetailDTO detailDTO);
        Task<DetailDTO> GetByIdAsync(long Id);
        Task<DetailDTO> DeleteAsync(long Id);
    }
}
