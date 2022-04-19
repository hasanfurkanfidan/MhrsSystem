using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IAuthService _authService;
        public BaseController()
        {

        }
        public BaseController(IAuthService authService)
        {
            _authService = authService;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResult(Core.Utilities.Results.IResult result)
        {
            return result.Success ? Ok() : BadRequest(result.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<JwtAuthUser> GetLoggedUserInformation()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(authHeader))
                throw new Exception(Messages.AuthorizationDenied);

            var userDataClaim = await _authService.GetClaim(authHeader, ClaimTypes.UserData);

            if (!userDataClaim.Success)
                throw new Exception(Messages.AuthorizationDenied);

            var jwtAuthUser = JsonConvert.DeserializeObject<JwtAuthUser>(userDataClaim.Data);
            if (jwtAuthUser == null)
                throw new Exception(Messages.AuthorizationDenied);

            return jwtAuthUser;
        }
    }
}
