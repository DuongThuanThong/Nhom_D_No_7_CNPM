using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IWaterParameterService
    {
        Task<List<WaterParameter>> GetAllWaterParameter();
        Task<WaterParameter?> GetById(int id);
        Task<bool> AddWaterParameter(WaterParameter waterParameter);
        Task<bool> UpdateWaterParameter(WaterParameter waterParameter);
        Task<bool> DeleteWaterParameter(int id);

    }
}
