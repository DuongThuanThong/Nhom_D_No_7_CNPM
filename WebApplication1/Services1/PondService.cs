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
    public class PondService : IPondService
    {
        private readonly IPondRepository _repository;
        public PondService(IPondRepository repository) { 
            _repository = repository;
        }

        public async Task<bool> AddPond(Pond pond)
        {
           return await _repository.AddPond(pond);
        }

        public async Task<bool> DeletePond(int id)
        {
            return await _repository.DeletePond(id);
        }

        public async Task<List<Pond>> GetAllPond()
        {
            return await _repository.GetAllPond();
        }

        public async Task<Pond?> GetById(int id)
        {
           return await _repository.GetById(id);
        }

        public async Task<bool> UpdatePond(Pond pond)
        {
            return await _repository.UpdatePond(pond);
        }
    }
}
