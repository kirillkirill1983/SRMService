using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository.Workers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Workers
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(WorkerDTO workerDTO)
        {
            var worker = _mapper.Map<WorkerDTO,Worker>(workerDTO);
            var result = await _workerRepository.Add(worker);
            return result;
        }

        public async Task<WorkerDTO> DeleteAsync(long Id)
        {
            Worker result = await _workerRepository.Delete(Id);
            var worker = _mapper.Map<Worker, WorkerDTO>(result);
            return worker;
        }

        public async Task<List<WorkerDTO>> GetAllAsynk()
        {
            var result = await _workerRepository.GetAll();
            return _mapper.Map<List<Worker>, List<WorkerDTO>>(result);
        }

        public async Task<WorkerDTO> GetByIdAsync(long Id)
        {
            var result = await _workerRepository.GetById(Id);
            var worker = _mapper.Map<Worker, WorkerDTO>(result);
            return worker;

        }

        public async Task<bool> UpDateAsync(WorkerDTO workerDTO)
        {
            var worker = _mapper.Map<WorkerDTO, Worker>(workerDTO);
            var result = await _workerRepository.Update(worker);
            return result;


        }
    }
}
