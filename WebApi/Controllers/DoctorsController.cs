using Business.Abstract;
using Entities.Dtos.Doctor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : BaseController
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(DoctorCreateDto doctorCreateDto)
        {
            return base.GetResponseOnlyResult(await _doctorService.Create(doctorCreateDto));
        }
    }
}
