using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Cars
{
    public class CarService:ICarService
    {
        private readonly ICarRepository _carRepository;
    
       
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<bool> AddAsync(Car car)
        {
            var tabl = new Car();
            tabl.CustomerId = car.CustomerId;
            tabl.CarModel = car.CarModel;
            tabl.Number = tabl.Number;
            tabl.Date = car.Date;
            var result = await _carRepository.Add(tabl);
            return result;
        }

        public async Task<Car> DeleteAsync(long Id)
        {
            try
            {
                Car result = await _carRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  async Task<List<Car>> GetAllAsynk()
        {
            var carList = new List<Car>();
            var result = await _carRepository.GetAll();
            foreach (var item in result)
            {
                carList.Add(new Car
                {
                    Id = item.Id,
                    CustomerId = item.CustomerId,
                     CarModel=item.CarModel,
                      Number=item.Number,
                      Date=item.Date
                    
                });

            }
            return carList;
        }

        public async Task<Car> GetByIdAsync(long Id)
        {
            var result = await _carRepository.GetById(Id);
            var table = new Car();
            table.CustomerId = result.CustomerId;
            table.CarModel = result.CarModel;
            table.Number = result.Number;
            table.Date = result.Date;

            return table;
        }

        public async Task<bool> UpDateAsync(Car car)
        {
            try
            {
                var tabl = new Car();
                tabl.CustomerId = car.CustomerId;
                tabl.CarModel = car.CarModel;
                tabl.Number = car.Number;
                tabl.Date = car.Date;

                var result = await _carRepository.Update(tabl);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
