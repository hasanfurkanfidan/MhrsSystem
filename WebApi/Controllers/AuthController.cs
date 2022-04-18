using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("create-admin-user")]
        public async Task<IActionResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto)
        {
            var result = await _authService.CreateAdminUser(createAdminUserDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
