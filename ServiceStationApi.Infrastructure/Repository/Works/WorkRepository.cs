using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Works
{
    public class WorkRepository : IWorkRepository
    {
        private readonly ApplicationContext _context;
        public WorkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Work work)
        {
            try
            {
                await _context.Works.AddAsync(work);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            };
        }

        public async Task<Work> Delete(long Id)
        {
            try
            {
                var result = await _context.Works.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Works.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<Work>> GetAll()
        {
            var result = await _context.Works.Include(p=>p.Details).ToListAsync();
            return result;
        }

        public async Task<Work> GetById(long Id)
        {

            var result = await _context.Works.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Work work)
        {
            try
            {
                _context.Works.Update(work);
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
