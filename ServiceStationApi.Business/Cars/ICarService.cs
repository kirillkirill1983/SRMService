using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Cars
{
    public interface ICarService
    {
        Task<bool> AddAsync(CarDTO carDTO);
        Task<List<CarDTO>> GetAllAsynk();
        Task<bool> UpDateAsync(CarDTO carDTO);
        Task<CarDTO> GetByIdAsync(long Id);
        Task<CarDTO> DeleteAsync(long Id);
    }
}
