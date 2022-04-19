using AutoMapper;
using Business.Abstract;
using Entities.Dtos.Hospital;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IHospitalService _hospitalService;
        public HospitalController(IMapper mapper, IHospitalService hospitalService)
        {
            _mapper = mapper;
            _hospitalService = hospitalService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(HospitalCreateDto hospitalCreateDto)
        {
            return base.GetResponseOnlyResult(await _hospitalService.CreateHospital(hospitalCreateDto));
        }
    }
}
