using Application.Services;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await userService.LoginAsync(loginModel);
            return Ok(result);
        }
        [HttpPost("productId")]
        public async Task<IActionResult> GetUsersByProductId(Guid id)
        {
            var result = await userService.GetUsersByProductIdAsync(id);
            return Ok(result);
        }
        [HttpGet("check")]
        public async Task<IActionResult> CheckUsersByProductCode(string code)
        {
            var result = await userService.CheckUsersByProductCodeAsync(code);
            return Ok(result);
        }
        [HttpPost("signup")]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            var result = await userService.AddUser(userDto);
            return Ok(result);
        }
        [HttpPost("checkemail")]
        public async Task<IActionResult> CheckEmailValid(String email)
        {

            var result = await userService.CheckEmail(email);
            return Ok(result);
        }
        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(Guid id, ChangePassword password)
        {
            if (!password.Password.Equals(password.ConfirmPassword))
                return BadRequest();
            await userService.ChangePassword(id, password.Password);
            return Ok();
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetUsers(int pageIndex, int pageSize)
        {
            var result = await userService.GetUsers(pageIndex, pageSize);
            return Ok(result);
        }
    }
}
