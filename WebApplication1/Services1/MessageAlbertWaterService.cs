using Respositories1.Entities;
using Respositories1.Interfaces;
using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1
{
    public class MessageAlbertWaterService:IMessageAlbertWaterService
    {
        private readonly IMessageAlbertWaterRepository _repository;
        public MessageAlbertWaterService(IMessageAlbertWaterRepository repository) {
            _repository = repository;
        }

        public async Task<bool> AddMessageAlbertWater(MessageAlbertWater messageAlbertWater)
        {
            return await _repository.AddMessageAlbertWater(messageAlbertWater);
        }

        public async Task<bool> DeleteMessageAlbertWater(int id)
        {
            return await _repository.DeleteMessageAlbertWater(id);
        }

        public async Task<List<MessageAlbertWater>> GetAllMessageAlbertWater()
        {
            return await _repository.GetAllMessageAlbertWater();
        }

        public async Task<MessageAlbertWater?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> UpdateMessageAlbertWater(MessageAlbertWater messageAlbertWater)
        {
            return await _repository.UpdateMessageAlbertWater(messageAlbertWater);
        }
    }
}
    