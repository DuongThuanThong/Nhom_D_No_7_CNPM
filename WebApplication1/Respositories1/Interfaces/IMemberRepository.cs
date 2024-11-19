using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMember();
        Task<Member?> GetById(int id);
        Task<Member> AddMember(Member member);
        Task<bool> UpdateMember(Member member);
        Task<bool> DeleteMember(int id);
        Task<Member?> GetMemberByPhone(string phone);
    }
}
