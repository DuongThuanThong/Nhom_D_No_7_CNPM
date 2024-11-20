using Respositories1.Entities;
using Services1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IPondService
    {
        Task<List<PondDTO>> GetAllPond(int userId);
        Task<Pond?> GetById(int id);
        Task<bool> AddPond(PondDTO ponddto);
        Task<bool> UpdatePond(Pond pond);
        Task<bool> DeletePond(int id);
    }
}
