using Microsoft.AspNetCore.Mvc;
using VeggieLink.Aplication.Dtos.User;
using VeggieLink.Aplication.Interfaces;

namespace VeggieLink.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IAuthService _authService;

        public UserController(IUserService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        [HttpPost]
        public async Task<AuthDto> CreateUser([FromBody] CreateUserDto dto)
        {
            return await _service.CreateUser(dto);
        }
        [HttpPost("login")]
        public async Task<AuthDto> Login([FromBody] LoginDto dto)
        {
            return await _authService.Login(dto);
        }
    }
}