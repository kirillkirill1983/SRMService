using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Cars
{
    public interface ICarRepository
    {
        Task<bool> Add(Car car);
        Task<bool> Update(Car car);
        Task<List<Car>> GetAll();
        Task<Car> Delete(long Id);
        Task<Car> GetById(long Id);
    }
}

