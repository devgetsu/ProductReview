using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(LoginDTO user);
    }
}
