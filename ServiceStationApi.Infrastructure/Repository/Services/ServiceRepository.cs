using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Services
{
    
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationContext _context;
        public ServiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Service service)
        {
            try
            {
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            };
        }

        public async Task<Service> Delete(long Id)
        {
            try
            {
                var result = await _context.Services.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Services.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<Service>> GetAll()
        {
            var result = await _context.Services.ToListAsync();
            return result;
        }

        public async Task<Service> GetById(long Id)
        {

            var result = await _context.Services.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Service service)
        {
            try
            {
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
