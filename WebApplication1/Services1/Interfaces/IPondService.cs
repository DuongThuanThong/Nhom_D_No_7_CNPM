using Respositories1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IPondService
    {
        Task<List<Pond>> GetAllPond();
        Task<Pond?> GetById(int id);
        Task<bool> AddPond(Pond pond);
        Task<bool> UpdatePond(Pond pond);
        Task<bool> DeletePond(int id);
    }
}
