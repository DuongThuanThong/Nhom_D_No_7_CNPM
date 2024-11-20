using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1.Interfaces
{
    public interface IGrowthKoiRepository
    {
        Task<List<GrowthKoi>> GetAllGrowthKoi(int koiId);
        Task<GrowthKoi?> GetByIdGrowthKoi(int id);
        Task<bool> AddGrowthKoi(GrowthKoi growthKoi);
        Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi);
        Task<bool> DeleteGrowthKoi(int id);
        Task<GrowthKoi?> GetGrowthKoi(int KoiIdid);
    }
}
