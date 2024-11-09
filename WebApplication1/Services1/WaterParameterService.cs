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
    public class WaterParameterService : IWaterParameterService
    {
        private readonly IWaterParameterRepository _repository;

        public WaterParameterService(IWaterParameterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddWaterParameter(WaterParameter waterParameter)
        {
            return await _repository.AddWaterParameter(waterParameter);
        }

        public async Task<bool> DeleteWaterParameter(int id)
        {
            return await (_repository.DeleteWaterParameter(id));
        }

        public async Task<List<WaterParameter>> GetAllWaterParameter()
        {
            return await (_repository.GetAllWaterParameter());
        }

        public async Task<WaterParameter?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> UpdateWaterParameter(WaterParameter waterParameter)
        {
            return await _repository.UpdateWaterParameter(waterParameter);
        }
    }
}
