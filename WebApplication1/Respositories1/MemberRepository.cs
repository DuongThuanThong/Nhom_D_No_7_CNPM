using Respositories1.Entities;
using Respositories1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Respositories1
{
    public class MemberRepository :IMemberRepository
    {
        private readonly KoiCareSystemAhContext _context;

        public MemberRepository(KoiCareSystemAhContext context)
        {
            _context = context; 
        }

        public async Task<bool> AddMember(Member member)
        {
            try
            {
                await _context.AddAsync(member);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMember(int id)
        {
            try
            {
                var Member = await _context.Members.FindAsync(id);
                if (Member != null)
                {
                    _context.Members.Remove(Member);
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

        public async Task<List<Member>> GetAllMember()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetById(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<bool> UpdateMember(Member member)
        {
            try
            {
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
