using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository.Works;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Works
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<bool> AddAsync(Work work)
        {
            var tabl = new Work();
            tabl.TypeWokr = work.TypeWokr;
            tabl.Price = tabl.Price;
            var result = await _workRepository.Add(tabl);
            return result;
        }

        public async Task<Work> DeleteAsync(long Id)
        {
            try
            {
                Work result = await _workRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Work>> GetAllAsynk()
        {
            var worklList = new List<Work>();
            var result = await _workRepository.GetAll();
            foreach (var item in result)
            {
                worklList.Add(new Work
                {
                    Id = item.Id,
                    TypeWokr = item.TypeWokr,
                    Price = item.Price

                });

            }
            return worklList;
        }

        public async Task<Work> GetByIdAsync(long Id)
        {
            var result = await _workRepository.GetById(Id);
            var table = new Work();
            table.TypeWokr = result.TypeWokr;
            table.Price = result.Price;
            return table;
        }

        public async Task<bool> UpDateAsync(Work work)
        {
            try
            {
                var tabl = new Work();
                tabl.TypeWokr = work.TypeWokr;
                tabl.Price = work.Price;

                var result = await _workRepository.Update(tabl);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
