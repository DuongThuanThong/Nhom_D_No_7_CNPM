using Respositories1.Entities;
using Respositories1.Interfaces;
using Services1.DTO;
using Services1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemberRepository _memberRepository;

        public UserService (IUserRepository userRepository, IMemberRepository memberRepository)
        {
            _userRepository = userRepository;
            _memberRepository = memberRepository;
        }
        public async Task<bool> AddUser(RegisterDTO registerdto)
        {
            try
            {

                var user = new User
                {
                    Username = registerdto.UserName != null  ? registerdto.UserName : "",
                    Email = registerdto.Email != null ? registerdto.Email : "",
                    Password = registerdto.Password != null ? registerdto.Password : "",
                    RoleId = 2
                };


                var newUser = await _userRepository.AddUser(user);

                var member = new Member
                {
                    Phone = registerdto.Phone,
                    UserId = newUser.UserId,
                };

                var newMember = await _memberRepository.AddMember(member);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User?> checkLogin(LoginDTO loginDTO)
        {
           var user = await _userRepository.GetUserByEmail(loginDTO.Email != null ? loginDTO.Email : "");
           if (user == null)
            {
                return null;
            }

            if (user.Password != loginDTO.Password) {
                return null;

            }

            return user; 
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await  _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<bool> isEmailExists(string email)
        {
            return await _userRepository.GetUserByEmail(email) != null;
        }

        public async Task<bool> isPhoneExists(string phone)
        {
            return await _memberRepository.GetMemberByPhone(phone) != null;
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}
