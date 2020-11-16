using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Works
{
    public interface IWorkRepository
    {
        Task<bool> Add(Work work);
        Task<bool> Update(Work work);
        Task<List<Work>> GetAll();
        Task<Work> Delete(long Id);
        Task<Work> GetById(long Id);
    }
}
