using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respositories1.Interfaces;
using Respositories1.Models;

namespace Services1
{
	public class KoiService: IKoiService
	{
		private readonly  IKoiRespository _repository;
		public KoiService(IKoiRespository repository) 
		{
			_repository = repository;
		}

		public async Task<List<Koi>> GetAllKoi()
		{
			return await _repository.GetAllKoi();
		}

		public async Task<bool> AddKoi(Koi koi)
		{
			return await _repository.AddKoi(koi);
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
	}
}
