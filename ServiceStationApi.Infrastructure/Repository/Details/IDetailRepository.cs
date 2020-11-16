using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ServiceStationApi.Infrastructure.Repository.Details
{
    public interface IDetailRepository
    {
        Task<bool> Add(Detail detail);
        Task<bool> Update(Detail detail);
        Task<List<Detail>> GetAll();
        Task<Detail> Delete(long Id);
        Task<Detail> GetById(long Id);

    }
}
