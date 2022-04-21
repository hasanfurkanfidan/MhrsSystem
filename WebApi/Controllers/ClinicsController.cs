using Business.Abstract;
using Business.Constants;
using Core.Constants;
using Entities.Dtos.Clinic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : BaseController
    {
        private readonly IClinicService _clinicService;
        public ClinicsController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ClinicCreateDto clinicCreateDto)
        {
            var logggedUser = await base.GetLoggedUserInformation();
            if (!logggedUser.Roles.Contains(EntityConstants.Roles.Admin))
                return BadRequest(Messages.AuthorizationDenied);

            return base.GetResponseOnlyResult(await _clinicService.CreateClinic(clinicCreateDto));
        }
    }
}
