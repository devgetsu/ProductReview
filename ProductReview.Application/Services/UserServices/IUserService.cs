using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.UserServices
{
    public interface IUserService
    {
        public Task<User> CreateUser(string path, UserDTO usDTO);
        public Task<User> UpdateUserByName(string name, UserDTO usDTO);
        public Task<User> UpdateUserById(int id, UserDTO usDTO);
        public Task<bool> DeleteUserById(int id);
        public Task<bool> DeleteUserByName(string name);
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByName(string name);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
