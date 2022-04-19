using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _authService.Login(loginRequestDto);
            return base.GetResponseOnlyResultData(result);
        }
        [HttpPost("create-admin-user")]
        public async Task<IActionResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto)
        {
            var result = await _authService.CreateAdminUser(createAdminUserDto);
            return base.GetResponseOnlyResult(result);
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _authService.CreateUser(createUserDto);
            return base.GetResponseOnlyResult(result);
        }

    }
}
