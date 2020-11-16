using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Works
{
    public interface IWorkService
    {
        Task<bool> AddAsync (Work work);
        Task<List<Work>> GetAllAsynk();
        Task<bool> UpDateAsync(Work work);
        Task<Work> GetByIdAsync(long Id);
        Task<Work> DeleteAsync(long Id);
    }
}
