using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1.Interfaces
{
    public interface IMessageAlbertWaterRepository
    {
        Task<List<MessageAlbertWater>> GetAllMessageAlbertWater();
		Task<MessageAlbertWater?>GetById(int id);
		Task<bool> AddMessageAlbertWater(MessageAlbertWater messageAlbertWater);
		Task<bool> UpdateMessageAlbertWater(MessageAlbertWater messageAlbertWater);
		Task<bool> DeleteMessageAlbertWater(int id);

    }
}
