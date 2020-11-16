using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Repository.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceStationApi.Business.Services
{
    public class ServiceService : IServiseService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async  Task<bool> AddAsync(Service service)
        {
            var tabl = new Service();
            tabl.WorkerId = service.WorkerId;
            tabl.WorkId = service.WorkId;
            tabl.Description = service.Description;
            tabl.CarId = service.CarId;
            tabl.Date = service.Date;
            var result = await _serviceRepository.Add(tabl);
            return result;
        }

        public async Task<Service> DeleteAsync(long Id)
        {
            try
            {
                Service result = await _serviceRepository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Service>> GetAllAsynk()
        {
            var servicelList = new List<Service>();
            var result = await _serviceRepository.GetAll();
            foreach (var item in result)
            {
                servicelList.Add(new Service
                {
                    Id = item.Id,
                    WorkerId = item.WorkerId,
                    WorkId = item.WorkId,
                    Description=item.Description,
                    CarId=item.CarId,
                    Date=item.Date

                });

            }
            return servicelList;
        }

        public async Task<Service> GetByIdAsync(long Id)
        {
            var result = await _serviceRepository.GetById(Id);
            var table = new Service();
            table.WorkerId = result.WorkerId;
            table.WorkId = result.WorkId;
            table.Description = result.Description;
            table.CarId = result.CarId;
            table.Date = result.Date;
            return table;
        }

        public async Task<bool> UpDateAsync(Service service)
        {
            try
            {
                var table = new Service();
                table.WorkerId = service.WorkerId;
                table.WorkId = service.WorkId;
                table.Description = service.Description;
                table.CarId = service.CarId;
                table.Date = service.Date;

                var result = await _serviceRepository.Update(table);
                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
