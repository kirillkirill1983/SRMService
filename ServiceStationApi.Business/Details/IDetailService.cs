using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Details
{
    public interface IDetailService
    {
        Task<bool> AddAsync(Detail detail);
        Task<List<Detail>> GetAllAsynk();
        Task<bool> UpDateAsync(Detail detail);
        Task<Detail> GetByIdAsync(long Id);
        Task<Detail> DeleteAsync(long Id);
    }
}
