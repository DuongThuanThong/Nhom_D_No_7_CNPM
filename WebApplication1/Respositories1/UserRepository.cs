using Microsoft.EntityFrameworkCore;
using Respositories1.Entities;
using Respositories1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories1
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiCareSystemAhContext _context;
        public UserRepository(KoiCareSystemAhContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }


        public async Task<User> AddUser(User user)
        {
             await _context.AddAsync(user);
             await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User?> GetUserById(int id)
        {

            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
