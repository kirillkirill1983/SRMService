using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CarDTO carDto)
        {
            var car = _mapper.Map<CarDTO, Car>(carDto);
            var result = await _carRepository.Add(car);
            return result;
        }

        public async Task<CarDTO> DeleteAsync(long Id)
        {
            Car result = await _carRepository.Delete(Id);
            var car = _mapper.Map<Car, CarDTO>(result);

            return car;
        }

        public async Task<List<CarDTO>> GetAllAsynk()
        {
            var result = await _carRepository.GetAll();
            return _mapper.Map<List<Car>, List<CarDTO>>(result);
        }

        public async Task<CarDTO> GetByIdAsync(long Id)
        {
            var result = await _carRepository.GetById(Id);
            var car = _mapper.Map<Car, CarDTO>(result);
            return car;
        }

        public async Task<bool> UpDateAsync(CarDTO carDTO)
        {
            var car = _mapper.Map<CarDTO, Car>(carDTO);

            var result = await _carRepository.Update(car);
            return result;


        }
    }
}
