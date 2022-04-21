using Business.Abstract;
using Business.Constants;
using Core.Constants;
using Entities.Dtos.Branch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : BaseController
    {
        private readonly IBranchService _branchService;
        public BranchesController(IBranchService branchService, IAuthService authService) : base(authService)
        {
            _branchService = branchService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateDto branchCreateDto)
        {
            var loggedUser = await base.GetLoggedUserInformation();
            if (!loggedUser.Roles.Contains(EntityConstants.Roles.Admin))
                return BadRequest(Messages.AuthorizationDenied);

            return base.GetResponseOnlyResult(await _branchService.Create(branchCreateDto));
        }
    }
}
