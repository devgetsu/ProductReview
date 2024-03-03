using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.API.Filter;
using ProductReview.Application.Services.UserServices;
using ProductReview.Domain.DTOs;

namespace ProductReview.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [PermissionFilter(permission: "GetAll")]
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
        [PermissionFilter(permission:"CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.CreateUser(null, userDTO); // Assuming 'path' is not relevant for this endpoint
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [PermissionFilter(permission:"UpdateUser")]
        public async Task<IActionResult> UpdateUserById(int id, UserDTO userDTO)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserById(id, userDTO);
                if (updatedUser == null)
                    return NotFound();

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [PermissionFilter(permission:"DeleteUser")]
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
