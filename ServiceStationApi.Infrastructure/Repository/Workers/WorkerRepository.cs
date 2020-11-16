using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Workers
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ApplicationContext _context;
        public WorkerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Worker worker)
        {
            try
            {
                await _context.Workers.AddAsync(worker);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            };
        }

        public async Task<Worker> Delete(long Id)
        {
            try
            {
                var result = await _context.Workers.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Workers.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<Worker>> GetAll()
        {
            var result = await _context.Workers.ToListAsync();
            return result;
        }

        public async Task<Worker> GetById(long Id)
        {

            var result = await _context.Workers.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Worker worker)
        {
            try
            {
                _context.Workers.Update(worker);
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
