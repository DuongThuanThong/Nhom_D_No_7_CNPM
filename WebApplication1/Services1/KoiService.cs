using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respositories1.Interfaces;
using Respositories1.Entities;
using Services1.DTO;

namespace Services1
{
	public class KoiService: IKoiService
	{
		private readonly  IKoiRespository _repository;
		public KoiService(IKoiRespository repository) 
		{
			_repository = repository;
		}

		public async Task<int> AddKoi(KoiDTO koidto)
		{
			var newKoi = new Koi()
			{
				Name = koidto.Name,
				Gender = koidto.Gender,
				Breed = koidto.Breed,
				Origin = koidto.Origin,
				PondId = koidto.PondId,
				UserId = koidto.UserId
			};

            return await _repository.AddKoi(newKoi);
        }

		public async Task<bool> DeleteKoi(int id)
		{
			return await _repository.DeleteKoi(id);
		}

		public async Task<Koi?> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<bool> UpdateKoi(Koi koi)
		{
			return await _repository.UpdateKoi(koi);
		}

        public async Task<List<KoiDTO>> GetAllKoi(int userId)
        {
            var kois = await _repository.GetAllKoi(userId);

            if (kois == null)
            {
				Console.WriteLine("hello");
                return new List<KoiDTO>();
            }
            List<KoiDTO> KoiDTOs = new List<KoiDTO>();

            foreach (var koi in kois)
            {
                var koiDTO = new KoiDTO
                {
                  KoiId = koi.KoiId,
				  Name = koi.Name,
				  Gender = koi.Gender,
				  Breed = koi.Breed,
				  Origin = koi.Origin,
				  PondId = koi.PondId,
                };
                KoiDTOs.Add(koiDTO);
            }
            return KoiDTOs;
        }
    }
}
