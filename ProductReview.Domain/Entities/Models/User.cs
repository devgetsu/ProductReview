using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Domain.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string PicturePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public static string HashPassword(string password,string salt)
        {
            int key_size = 32;
            int iteration_count = 1000;
            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(
               password: password,
               salt: Encoding.UTF8.GetBytes(salt),
               iterations: iteration_count,
               hashAlgorithm: HashAlgorithmName.SHA256))
            {
                var bytes = algorithm.GetBytes(key_size);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
