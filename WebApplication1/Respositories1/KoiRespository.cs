using Respositories1.Interfaces;
using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Respositories1
{
	public class KoiRespository : IKoiRespository
	{
		private readonly KoiCareSystemAhContext _context;

		public	KoiRespository (KoiCareSystemAhContext context)
		{
			_context = context;
		}

		public async Task<List<Koi>> GetAllKoi()
		{
			return await _context.Kois.ToListAsync();
		}

		public async Task<Koi?> GetById(int id)
		{
			return await _context.Kois.FindAsync(id);
		}

		public async Task<int> AddKoi(Koi koi)
		{
				await _context.Kois.AddAsync(koi);
				await _context.SaveChangesAsync();
				return koi.KoiId;
		}
		
		public async Task<bool> UpdateKoi(Koi koi)
		{
			try
			{
				_context.Kois.Update(koi);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception) 
			{
				return false;
			}
		}



		public async Task<bool> DeleteKoi(int id)
		{
			try
			{
				var koi = await _context.Kois.FindAsync(id);
				if (koi != null)
				{
					_context.Kois.Remove(koi);
					await _context.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception) 
			{
				return false;
			}
		}
	}
}
