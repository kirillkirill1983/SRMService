using ServiceStationApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Cars
{
    public interface ICarService
    {
        Task<bool> AddAsync(Car car);
        Task<List<Car>> GetAllAsynk();
        Task<bool> UpDateAsync(Car car);
        Task<Car> GetByIdAsync(long Id);
        Task<Car> DeleteAsync(long Id);
    }
}
