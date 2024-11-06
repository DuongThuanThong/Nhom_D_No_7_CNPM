using Respositories1.Models;
using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1
{
    public class GrowthKoiService : IGrowthKoiService
    {
        private readonly IGrowthKoiService _repository;
        public GrowthKoiService(IGrowthKoiService repository) 
        {
            _repository = repository;
        }
        public async Task<List<GrowthKoi>> GetAllGrowthKoi()
        {
            return await _repository.GetAllGrowthKoi();
        }
        public async Task<GrowthKoi?> GetByIdGrowthKoi(int id)
        {
            return await _repository.GetByIdGrowthKoi(id);
        }

        public async Task<bool> AddGrowthKoi(GrowthKoi growthKoi)
        {
            return await _repository.AddGrowthKoi(growthKoi);
        }

        public async Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi)
        {
            return await _repository.UpdateGrowthKoi(growthKoi);
        }
        public async Task<bool> DeleteGrowthKoi(int id)
        {
            return await _repository.DeleteGrowthKoi(id);
        }
    }
}
