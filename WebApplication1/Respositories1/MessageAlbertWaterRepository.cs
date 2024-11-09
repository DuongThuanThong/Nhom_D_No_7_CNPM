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
    public class MessageAlbertWaterRepository : IMessageAlbertWaterRepository
    {
        readonly KoiCareSystemAhContext _context;
        public MessageAlbertWaterRepository(KoiCareSystemAhContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMessageAlbertWater(MessageAlbertWater messageAlbertWater)
        {
            try
            {
                await _context.AddAsync(messageAlbertWater);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMessageAlbertWater(int id)
        {
            try
            {
                var MessageAlbertWater = await _context.MessageAlbertWaters.FindAsync(id);
                if (MessageAlbertWater != null)
                {
                    _context.MessageAlbertWaters.Remove(MessageAlbertWater);
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

        public async Task<List<MessageAlbertWater>> GetAllMessageAlbertWater()
        {
            return await _context.MessageAlbertWaters.ToListAsync();
        }

        public async Task<MessageAlbertWater?> GetById(int id)
        {
            return await _context.MessageAlbertWaters.FindAsync(id);
        }

        public async Task<bool> UpdateMessageAlbertWater(MessageAlbertWater messageAlbertWater)
        {
            try
            {
                _context.MessageAlbertWaters.Update(messageAlbertWater);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
