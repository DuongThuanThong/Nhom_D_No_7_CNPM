using Microsoft.EntityFrameworkCore;
using Respositories1.Interfaces;
using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1
{
    public class GrowthKoiRepository : IGrowthKoiRepository
    {
        private readonly KoiCareSystemAhContext _context;

        public GrowthKoiRepository(KoiCareSystemAhContext context)
        {
            _context = context;
        }
        public async Task<List<GrowthKoi>> GetAllGrowthKoi(int koiId)
        {
            return await _context.GrowthKois.Where(p=> p.KoiId == koiId).ToListAsync();
        }
        public async Task<GrowthKoi?> GetByIdGrowthKoi(int id)
        {
            return await _context.GrowthKois.FindAsync(id);
        }
        public async Task<bool> AddGrowthKoi(GrowthKoi growthKoi)
        {
            try
            {
                await _context.AddAsync(growthKoi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi)
        {
            try
            {
                _context.GrowthKois.Update(growthKoi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> DeleteGrowthKoi(int id)
        {
            try
            {
                var growthKoi = await _context.GrowthKois.FindAsync(id);
                if (growthKoi != null)
                {
                    _context.GrowthKois.Remove(growthKoi);
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

        public async Task<GrowthKoi?> GetGrowthKoi(int KoiIdid)
        {
            return await _context.GrowthKois.Where(k => k.KoiId == KoiIdid).OrderByDescending(k=>k.GrowthId).FirstOrDefaultAsync();
        }
    }
}
