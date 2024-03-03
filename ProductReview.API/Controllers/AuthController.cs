using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Application.Services.AuthServices;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Application.Services.UserServices;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using ProductReview.Infrastruct.Persistance;

namespace ProductReview.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] IFormFile picture, UserDTO userDTO)
        {

            var entry = await _userService.CreateUser("path", userDTO);

            return Ok("Yaratildi");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var token = _authService.GenerateToken(loginDTO);

            return Ok(token);
        }
    }
}
