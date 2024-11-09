using Respositories1.Entities;
using Respositories1.Interfaces;
using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1
{
    public class MemberService: IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService (IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddMember(Member member)
        {
           return await _repository.AddMember(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            return await _repository.DeleteMember(id);
        }

        public async Task<List<Member>> GetAllMember()
        {
            return await _repository.GetAllMember();
        }

        public async Task<Member?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> UpdateMember(Member member)
        {
            return await _repository.UpdateMember(member);
        }
    }
}
