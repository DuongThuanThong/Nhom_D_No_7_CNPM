using Respositories1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IGrowthKoiService
    {
        Task<List<GrowthKoi>> GetAllGrowthKoi();
        Task<GrowthKoi?> GetByIdGrowthKoi(int id);
        Task<bool> AddGrowthKoi(GrowthKoi growthKoi);
        Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi);
        Task<bool> DeleteGrowthKoi(int id);
    }
}
