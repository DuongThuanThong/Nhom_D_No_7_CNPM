using Respositories1.Entities;
using Services1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IGrowthKoiService
    {
        Task<List<GrowthKoiDTO>> GetAllGrowthKoi(int koiId);
        Task<GrowthKoi?> GetByIdGrowthKoi(int id);
        Task<bool> AddGrowthKoi(GrowthKoiDTO growthKoidto);
        Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi);
        Task<bool> DeleteGrowthKoi(int id);

        Task<GrowthKoiDTO?> GetGrowthKoi(int koiId);
    }
}
