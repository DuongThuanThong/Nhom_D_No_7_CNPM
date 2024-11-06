using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respositories1.Models;

namespace Services1.Interfaces
{
	public interface IKoiService
	{
		Task<List<Koi>> GetAllKoi();
		Task<Koi?> GetById(int id);
		Task <bool> AddKoi(Koi koi);
		Task <bool> UpdateKoi(Koi koi);
		Task <bool> DeleteKoi(int id);
	}
}
