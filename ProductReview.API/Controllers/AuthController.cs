using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.API.ExternalServices;
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
        private readonly IWebHostEnvironment _env;


        public AuthController(IAuthService authService, IUserService userService,IWebHostEnvironment esv)
        {
            _authService = authService;
            _userService = userService;
            _env = esv;
        }

        [HttpPost]
        public async Task<string> Register([FromForm] UserDTO userDTO, IFormFile file)
        {
            PictureExternalService service = new PictureExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(file);

            var entry = await _userService.CreateUser(picturePath, userDTO);

            return "Yaratildi";
        }

        [HttpPost]

        public async Task<string> Login([FromForm] LoginDTO loginDTO)
        {
            var token = await _authService.GenerateToken(loginDTO);

            return token;
        }
    }
}
