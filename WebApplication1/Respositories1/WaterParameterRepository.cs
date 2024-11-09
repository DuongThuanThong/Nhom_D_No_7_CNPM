using Microsoft.EntityFrameworkCore;
using Respositories1.Entities;
using Respositories1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1
{
    public class WaterParameterRepository :IWaterParameterRepository
    {
        private readonly KoiCareSystemAhContext _context;
        public WaterParameterRepository(KoiCareSystemAhContext context) {
            _context = context;
        }

        public async Task<bool> AddWaterParameter(WaterParameter waterParameter)
        {
            try
            {
                await _context.WaterParameters.AddAsync(waterParameter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteWaterParameter(int id)
        {
            try
            {
                var waterParameter = await _context.WaterParameters.FindAsync(id);
                if (waterParameter != null)
                {
                    _context.WaterParameters.Remove(waterParameter);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<WaterParameter>> GetAllWaterParameter()
        {
            return await _context.WaterParameters.ToListAsync();
        }

        public async Task<WaterParameter?> GetById(int id)
        {
            return await _context.WaterParameters.FindAsync(id);
        }

        public async Task<bool> UpdateWaterParameter(WaterParameter waterParameter)
        {
            try
            {
                _context.WaterParameters.Update(waterParameter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
