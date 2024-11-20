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
    public class PondRespository : IPondRepository
    {
        private readonly KoiCareSystemAhContext _context;
        public PondRespository(KoiCareSystemAhContext context)
        {
            _context = context;
        }

        public async Task<List<Pond>> GetAllPond(int userId)
        {
            return await _context.Ponds.Where(p => p.UserId == userId).ToListAsync();
        }
        public async Task<Pond?> GetById(int id)
        {
            return await _context.Ponds.FindAsync(id);  
        }

        public async Task<bool> AddPond(Pond pond)
        {
            try
            {
                await _context.AddAsync(pond);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdatePond(Pond pond)
        {
            try
            {
                _context.Ponds.Update(pond);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> DeletePond(int id)
        {
            try
            {
                var Pond = await _context.Ponds.FindAsync(id);
                if (Pond != null)
                {
                    _context.Ponds.Remove(Pond);
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
            
    }
}
