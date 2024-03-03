using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;

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
            var checker = await _usRepo.GetByAny(x => x.Login == usDTO.Login || x.Email == usDTO.Email);
            if (checker == null)
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
                    Role = usDTO.Role,
                });
                return res;
            }
            else
            {
                return new User() { };
            }
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

        public async Task<User> GetUserByLogin(string login)
        {
            return await _usRepo.GetByAny(x => x.Login == login);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _usRepo.GetByAny(x => x.Name == name);
        }

        public async Task<User> UpdateUserById(int id, UserDTO usDTO, string path)
        {
            var user = await _usRepo.GetByAny(x => x.Id == id);
            if (user == null)
            {
                return new User() { Name = "User is not found" };
            }
            else
            {

                if (usDTO.Email != user.Email && !_usRepo.GetAll().Result.Any(x => x.Email == usDTO.Email))
                {
                    user.Email = usDTO.Email;
                }
                else
                {
                    return new User() { Email = "Email is already exists" };
                }


                if (usDTO.Login != user.Login && !_usRepo.GetAll().Result.Any(x => x.Login == usDTO.Login))
                {
                    user.Login = usDTO.Login;
                }
                else
                {
                    return new User() { Login = "Login is blocked" };
                }

                var pass = _psHasher.Encrypt(usDTO.Password, user.Salt);
                user.Name = usDTO.Name;
                user.Email = usDTO.Email;
                user.Login = usDTO.Login;
                user.PasswordHash = pass;
                user.PicturePath = path;
                user.Role = usDTO.Role;
                var res = await _usRepo.Update(user);
                return res;
            }
        }

        public async Task<User> UpdateUserByName(string name, UserDTO usDTO, string path)
        {
            var user = await _usRepo.GetByAny(x => x.Name == name);

            if (user == null)
            {
                return new User() { Name = "User is not found" };
            }

            if (usDTO.Email != user.Email && !_usRepo.GetAll().Result.Any(x => x.Email == usDTO.Email))
            {
                user.Email = usDTO.Email;
            }
            else
            {
                return new User() { Email = "Email is already exists" };
            }


            if (usDTO.Login != user.Login && !_usRepo.GetAll().Result.Any(x => x.Login == usDTO.Login))
            {
                user.Login = usDTO.Login;
            }
            else
            {
                return new User() { Login = "Login is blocked" };
            }

            var pass = _psHasher.Encrypt(usDTO.Password, user.Salt);

            user.Name = usDTO.Name;
            user.Email = usDTO.Email;
            user.Login = usDTO.Login;
            user.PasswordHash = pass;
            user.PicturePath = path;
            user.Role = usDTO.Role;

            var updatedUser = await _usRepo.Update(user);

            return updatedUser;
        }

    }
}

