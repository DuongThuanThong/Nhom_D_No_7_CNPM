using Respositories1.Entities;
using Services1.Interfaces;
using Respositories1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services1.DTO;

namespace Services1
{
    public class GrowthKoiService : IGrowthKoiService
    {
        private readonly IGrowthKoiRepository _repository;
        public GrowthKoiService(IGrowthKoiRepository repository) 
        {
            _repository = repository;
        }
        public async Task<List<GrowthKoiDTO>> GetAllGrowthKoi(int koiId)
        {
            var growthKois = await _repository.GetAllGrowthKoi(koiId);

            if (growthKois == null) { 
                return new List<GrowthKoiDTO>();
            }
            List<GrowthKoiDTO> GrowthKoiDTOs = new List<GrowthKoiDTO>();

            foreach (var growthKoi in growthKois)
            {
                var growthKoiDTO = new GrowthKoiDTO
                {
                    GrowthId = growthKoi.GrowthId,
                    Image  = growthKoi.Image,
                    Size = growthKoi.Size,
                    Weight = growthKoi.Weight,
                    BodyShape = growthKoi.BodyShape,
                    Age = growthKoi.Age,
                    Price = growthKoi.Price,
                    GrowDate = growthKoi.GrowDate,

                };
                GrowthKoiDTOs.Add(growthKoiDTO);
            }
            return GrowthKoiDTOs;
}
        public async Task<GrowthKoi?> GetByIdGrowthKoi(int id)
        {
            return await _repository.GetByIdGrowthKoi(id);
        }

        public async Task<bool> AddGrowthKoi(GrowthKoiDTO growthKoidto)
        {
            var newGrowthKoi = new GrowthKoi()
            {
                KoiId = growthKoidto.KoiId,
                Image = growthKoidto.Image,
                Size = growthKoidto.Size,
                Weight = growthKoidto.Weight,
                BodyShape = growthKoidto.BodyShape,
                Age = growthKoidto.Age,
                Price = growthKoidto.Price
            };

            return await _repository.AddGrowthKoi(newGrowthKoi);
        }

        public async Task<bool> UpdateGrowthKoi(GrowthKoi growthKoi)
        {
            return await _repository.UpdateGrowthKoi(growthKoi);
        }
        public async Task<bool> DeleteGrowthKoi(int id)
        {
            return await _repository.DeleteGrowthKoi(id);
        }

        public async Task<GrowthKoiDTO?> GetGrowthKoi(int koiId)
        {
            var lastGrowthKoi = await _repository.GetGrowthKoi(koiId);
            if (lastGrowthKoi == null) return null;

            var newLastGrowKoi = new GrowthKoiDTO
            {
                GrowthId = lastGrowthKoi.GrowthId,
                KoiId = lastGrowthKoi.KoiId,
                Image = lastGrowthKoi.Image,
                Size = lastGrowthKoi.Size,
                Weight = lastGrowthKoi.Weight,
                BodyShape = lastGrowthKoi.BodyShape,
                Age = lastGrowthKoi.Age,
                Price = lastGrowthKoi.Price,
                GrowDate = lastGrowthKoi.GrowDate
            };
            return newLastGrowKoi;
        }
    }
}
