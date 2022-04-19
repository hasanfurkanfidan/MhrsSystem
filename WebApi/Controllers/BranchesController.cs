using Business.Abstract;
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
            var a = await base.GetLoggedUserInformation(); ;
            return base.GetResponseOnlyResult(await _branchService.Create(branchCreateDto));
        }
    }
}
