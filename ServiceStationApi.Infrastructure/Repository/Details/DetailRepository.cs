using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Details
{

    public class DetailRepository : IDetailRepository
    {
        private readonly ApplicationContext _context;
        public DetailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Detail detail)
        {
            try
            {
                await _context.Details.AddAsync(detail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            };
        }

        public async Task<Detail> Delete(long Id)
        {
            try
            {
                var result = await _context.Details.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Details.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<Detail>> GetAll()
        {
            var result = await _context.Details.Include(p=>p.Work).ToListAsync();
            return result;
        }

        public async Task<Detail> GetById(long Id)
        {

            var result = await _context.Details.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Detail detail)
        {
            try
            {
                _context.Details.Update(detail);
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