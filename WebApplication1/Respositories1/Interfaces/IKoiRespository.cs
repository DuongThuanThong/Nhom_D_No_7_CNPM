﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respositories1.Entities;

namespace Respositories1.Interfaces
{
	public interface IKoiRespository
	{
		Task<List<Koi>> GetAllKoi(int userId);
		Task<Koi?>GetById(int id);
		Task<int> AddKoi(Koi koi);
		Task<bool> UpdateKoi(Koi koi);
		Task<bool> DeleteKoi(int id);
	}
}
	