using AutoMapper;
using ServiceStationApi.Domain;
using ServiceStationApi.DTO;
using ServiceStationApi.Infrastructure.Repository.Details;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ServiceStationApi.Business.Details
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public DetailService(IDetailRepository detailRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(DetailDTO detailDTO )
        {
            var detail = _mapper.Map<DetailDTO, Detail>(detailDTO);
            var result = await _detailRepository.Add(detail);
            return result;
        }

        public async Task<DetailDTO> DeleteAsync(long Id)
        {
            Detail result = await _detailRepository.Delete(Id);
            var detail = _mapper.Map<Detail, DetailDTO>(result);

            return detail;
        }

        public async Task<List<DetailDTO>> GetAllAsynk()
        {
            var result = await _detailRepository.GetAll();
            return _mapper.Map<List<Detail>, List<DetailDTO>>(result);
        }

        public async Task<DetailDTO> GetByIdAsync(long Id)
        {
            var result = await _detailRepository.GetById(Id);
            var detail = _mapper.Map<Detail, DetailDTO>(result);
            return detail;
        }

        public async Task<bool> UpDateAsync(DetailDTO detailDTO)
        {
            var detail = _mapper.Map<DetailDTO, Detail>(detailDTO);

            var result = await _detailRepository.Update(detail);
            return result;


        }
    }
}
