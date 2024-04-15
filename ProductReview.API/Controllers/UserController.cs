using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.API.Attributes;
using ProductReview.API.ExternalServices;
using ProductReview.Application.Services.UserServices;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Enums;

namespace ProductReview.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;

        public UserController(IUserService userService, IWebHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }

        [HttpGet]
        //[IdentityFilter(Permission.GetUser)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[IdentityFilter(Permission.GetUser)]

        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        //[IdentityFilter(Permission.CreateUser)]

        public async Task<IActionResult> CreateUser([FromForm] UserDTO userDTO, IFormFile file)
        {
            try
            {
                PictureExternalService service = new PictureExternalService(_env);

                string picturePath = await service.AddPictureAndGetPath(file);

                var result = await _userService.CreateUser(picturePath, userDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[IdentityFilter(Permission.UpdateUser)]
        public async Task<IActionResult> UpdateUserById([FromForm] int id, UserDTO userDTO, IFormFile file)
        {
            try
            {
                PictureExternalService service = new PictureExternalService(_env);

                string picturePath = await service.AddPictureAndGetPath(file);

                var result = await _userService.UpdateUserById(id, userDTO, picturePath);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[IdentityFilter(Permission.DeleteUser)]

        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                var result = await _userService.DeleteUserById(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
