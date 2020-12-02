using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository.Works;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Works
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
        private readonly IMapper _mapper;

        public WorkService(IWorkRepository workRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(WorkDTO workDTO)
        {
            var work = _mapper.Map<WorkDTO,Work>(workDTO);
            var result = await _workRepository.Add(work);
            return result;
        }

        public async Task<WorkDTO> DeleteAsync(long Id)
        {
            Work result = await _workRepository.Delete(Id);
            var work = _mapper.Map<Work,WorkDTO>(result);
            return work;
        }

        public async Task<List<WorkDTO>> GetAllAsynk()
        {
            var result = await _workRepository.GetAll();
            return _mapper.Map<List<Work>, List<WorkDTO>>(result);
        }

        public async Task<WorkDTO> GetByIdAsync(long Id)
        {
            var result = await _workRepository.GetById(Id);
            var work = _mapper.Map<Work,WorkDTO>(result);
            return work;

        }

        public async Task<bool> UpDateAsync(WorkDTO workDTO)
        {
            var work = _mapper.Map<WorkDTO,Work>(workDTO);
            var result = await _workRepository.Update(work);
            return result;

        }
    }
}
