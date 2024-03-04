using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Application.Services.UserServices;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IConfiguration conf, IUserService userService, IPasswordHasher passwordHasher)
        {
            _conf = conf;
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> GenerateToken(LoginDTO user)
        {
            if (user == null)
            {
                return "User Not Found";
            }

            if (await UserExist(user))
            {
                var result = await _userService.GetUserByLogin(user.Login);
                var permissions = new List<int>();

                if (result.Role == "TeamLeader")
                {
                    permissions = new List<int>() { 1, 2, 5, 7, 9, 10, 11, 12 };
                }
                else if (result.Role == "User")
                {
                    permissions = new List<int>() { 8, 4, 9, 10, 11, 12 };
                }
                else if (result.Role == "Admin")
                {
                    permissions = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                }

                var jsonContent = JsonSerializer.Serialize(permissions);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Login", user.Login),
                    new Claim("UserID", result.Id.ToString()),
                    new Claim("Permissions", jsonContent),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                };

                return await GenerateToken(claims);
            }

            return "Un Authorize";
        }

        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<bool> UserExist(LoginDTO user)
        {
            var result = await _userService.GetUserByLogin(user.Login);
            try
            {

                if (user.Login == result.Login && _passwordHasher.Verify(result.PasswordHash, user.Password, result.Salt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
