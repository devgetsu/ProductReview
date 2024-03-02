using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        public string Encrypt(string password, string salt);
        public bool Verify(string hash, string password, string salt);
    }
}
