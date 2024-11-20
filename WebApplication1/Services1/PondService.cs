using Respositories1.Entities;
using Respositories1.Interfaces;
using Services1.DTO;
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

        public async Task<bool> AddPond(PondDTO ponddto)
        {
            var pond = new Pond
            {
                Name = ponddto.Name,
                Size = ponddto.Size,
                PumpCapacity = ponddto.PumpCapacity,
                DrainCount = ponddto.DrainCount,
                Volume = ponddto.Volume,
                Depth = ponddto.Depth,
                Image = ponddto.Image,
                UserId = ponddto.UserId,
            };
            return await _repository.AddPond(pond);
        }

        public async Task<bool> DeletePond(int id)
        {
            return await _repository.DeletePond(id);
        }

        public async Task<List<PondDTO>> GetAllPond(int userId)
        {
            var ponds = await _repository.GetAllPond(userId);

            if (ponds == null)
            {
                return new List<PondDTO>();
            }
            List<PondDTO> pondDTOs = new List<PondDTO>();

            foreach (var pond in ponds)
            {
                var pondDTO = new PondDTO
                {
                    PondId = pond.PondId,
                    Name = pond.Name,
                    Size = pond.Size,
                    PumpCapacity = pond.PumpCapacity,
                    DrainCount = pond.DrainCount,
                    Volume = pond.Volume,
                    Depth = pond.Depth,
                    Image = pond.Image
                };
                pondDTOs.Add(pondDTO);
            }
                return pondDTOs;
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
