using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respositories1.Entities;
using Services1.DTO;

namespace Services1.Interfaces
{
	public interface IKoiService
	{
		Task<List<KoiDTO>> GetAllKoi(int userId);
		Task<Koi?> GetById(int id);
		Task <int> AddKoi(KoiDTO koidto);
		Task <bool> UpdateKoi(Koi koi);
		Task <bool> DeleteKoi(int id);
	}
}
