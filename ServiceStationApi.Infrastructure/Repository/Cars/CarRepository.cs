using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationApi.Infrastructure.Repository.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationContext _context;
        public CarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Car car)
        {
            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            };
        }

        public async Task<Car> Delete(long Id)
        {
            try
            {
                var result = await _context.Cars.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Cars.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public async Task<List<Car>> GetAll()
        {
            var result = await _context.Cars.Include(p=>p.Customer).ToListAsync();
            return result;
        }

        public async Task<Car> GetById(long Id)
        {

            var result = await _context.Cars.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Car car)
        {
            try
            {
                _context.Cars.Update(car);
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