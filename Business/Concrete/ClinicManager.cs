using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Clinic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClinicManager : IClinicService
    {
        private readonly IClinicDal _clinicDal;
        private readonly IMapper _mapper;
        public ClinicManager(IClinicDal clinicDal, IMapper mapper)
        {
            _clinicDal = clinicDal;
            _mapper = mapper;
        }
        public async Task<IResult> CreateClinic(ClinicCreateDto clinicCreateDto)
        {
            var clinic = _mapper.Map<Clinic>(clinicCreateDto);
            await _clinicDal.AddAsync(clinic);
            return new SuccessResult();
        }
    }
}
