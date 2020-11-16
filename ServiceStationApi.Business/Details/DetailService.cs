using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository.Details;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ServiceStationApi.Business.Details
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository _detailRepository;
        public DetailService(IDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;

        }

        public async Task<bool> AddAsync(Detail detail)
        {
            var tabl = new Detail();
            tabl.WorkId = detail.WorkId;
            tabl.Name = detail.Name;
            tabl.Price = tabl.Price;
            var result = await _detailRepository.Add(tabl);
            return result;
        }

        public async Task<Detail> DeleteAsync(long Id)
        {
            try
            {
                Detail result = await _detailRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Detail>> GetAllAsynk()
        {
            var detailList = new List<Detail>();
            var result = await _detailRepository.GetAll();
            foreach (var item in result)
            {
                detailList.Add(new Detail
                {
                    Id = item.Id,
                    WorkId=item.WorkId,
                    Name=item.Name,
                    Price=item.Price

                });

            }
            return detailList;
        }

        public async Task<Detail> GetByIdAsync(long Id)
        {
            var result = await _detailRepository.GetById(Id);
            var table = new Detail();
            table.WorkId = result.WorkId;
            table.Name = result.Name;
            table.Price = result.Price;
            return table;
        }

        public async Task<bool> UpDateAsync(Detail detail)
        {
            try
            {
                var tabl = new Detail();
                tabl.WorkId = detail.WorkId;
                tabl.Name = detail.Name;
                tabl.Price = detail.Price;

                var result = await _detailRepository.Update(tabl);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
