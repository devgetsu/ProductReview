using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usRepo;
        private readonly IPasswordHasher _psHasher;

        public UserService(IUserRepository usRepo, IPasswordHasher psHasher)
        {
            _usRepo = usRepo;
            _psHasher = psHasher;
        }

        public async Task<User> CreateUser(string path, UserDTO usDTO)
        {
            var salt = Guid.NewGuid().ToString();
            var password = _psHasher.Encrypt(usDTO.Password, salt);
            var res = await _usRepo.Create(new User()
            {
                Name = usDTO.Name,
                Email = usDTO.Email,
                Login = usDTO.Login,
                PasswordHash = password,
                Salt = salt,
                PicturePath = path,
            });
            return res;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _usRepo.Delete(x => x.Id == id);
        }

        public async Task<bool> DeleteUserByName(string name)
        {
            return await _usRepo.Delete(x => x.Name == name);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _usRepo.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _usRepo.GetByAny(x => x.Id == id);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _usRepo.GetByAny(x => x.Name == name);
        }

        public async Task<User> UpdateUserById(int id, UserDTO usDTO)
        {
            var s = await _usRepo.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new User() { };
            }
            else
            {
                var pass = _psHasher.Encrypt(usDTO.Password, s.Salt);
                var res = await _usRepo.Update(new User {
                    Name = usDTO.Name,
                    Email = usDTO.Email,
                    Login = usDTO.Login,
                    PasswordHash = pass
                });
                return res;
            }
        }

        public async Task<User> UpdateUserByName(string name, UserDTO usDTO)
        {
            var s = await _usRepo.GetByAny(x => x.Name == name);
            if (s == null)
            {
                return new User() { };
            }
            else
            {
                var pass = _psHasher.Encrypt(usDTO.Password, s.Salt);
                var res = await _usRepo.Update(new User
                {
                    Name = usDTO.Name,
                    Email = usDTO.Email,
                    Login = usDTO.Login,
                    PasswordHash = pass
                });
                return res;
            }
        }
    }
}
