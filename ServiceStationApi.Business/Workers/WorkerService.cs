using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository.Workers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Workers
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<bool> AddAsync(Worker worker)
        {
            var tabl = new Worker();
            tabl.Name = worker.Name;
            tabl.Phone = worker.Phone;
            var result = await _workerRepository.Add(tabl);
            return result;
        }

        public async Task<Worker> DeleteAsync(long Id)
        {
            try
            {
                Worker result = await _workerRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Worker>> GetAllAsynk()
        {
            var workerlList = new List<Worker>();
            var result = await _workerRepository.GetAll();
            foreach (var item in result)
            {
                workerlList.Add(new Worker
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone

                });

            }
            return workerlList;
        }

        public async Task<Worker> GetByIdAsync(long Id)
        {
            var result = await _workerRepository.GetById(Id);
            var table = new Worker();
            table.Name = result.Name;
            table.Phone = result.Phone;
            return table;
        }

        public async Task<bool> UpDateAsync(Worker worker)
        {
            try
            {
                var tabl = new Worker();
                tabl.Name = worker.Name;
                tabl.Phone = worker.Phone;

                var result = await _workerRepository.Update(tabl);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
