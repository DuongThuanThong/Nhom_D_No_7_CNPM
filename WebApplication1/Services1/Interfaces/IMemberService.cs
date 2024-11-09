using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMember();
        Task<Member?> GetById(int id);
        Task<bool> AddMember(Member member);
        Task<bool> UpdateMember(Member member);
        Task<bool> DeleteMember(int id);
    }
}
