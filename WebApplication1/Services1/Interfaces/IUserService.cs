using Respositories1.Entities;
using Services1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<bool> AddUser(RegisterDTO registerdto);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User?> checkLogin(LoginDTO loginDTO);

        Task<bool> isEmailExists(string email);
        Task<bool> isPhoneExists(string phone);
    }
}
