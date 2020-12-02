using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Services
{
    public class ServiceService : IServiseService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(ServiceDTO serviceDTO)
        {
            var service = _mapper.Map<ServiceDTO, Service>(serviceDTO);
            var result = await _serviceRepository.Add(service);
            return result;
        }

        public async Task<ServiceDTO> DeleteAsync(long Id)
        {
            Service result = await _serviceRepository.Delete(Id);
            var service = _mapper.Map<Service, ServiceDTO>(result);
            return service;
        }

        public async Task<List<ServiceDTO>> GetAllAsynk()
        {
            var result = await _serviceRepository.GetAll();
            return _mapper.Map<List<Service>, List<ServiceDTO>>(result);
        }

        public async Task<ServiceDTO> GetByIdAsync(long Id)
        {
            var result = await _serviceRepository.GetById(Id);
            var service = _mapper.Map<Service, ServiceDTO>(result);
            return service;

        }

        public async Task<bool> UpDateAsync(ServiceDTO serviceDTO)
        {
            var service = _mapper.Map<ServiceDTO, Service>(serviceDTO);
            var result = await _serviceRepository.Update(service);
            return result;


        }
    }
}
