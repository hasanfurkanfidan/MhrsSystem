using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Doctor;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorDal _doctorDal;
        public DoctorManager(IMapper mapper, IDoctorDal doctorDal)
        {
            _mapper = mapper;
            _doctorDal = doctorDal;
        }
        public async Task<IResult> Create(DoctorCreateDto doctorCreateDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorCreateDto);
            await _doctorDal.AddAsync(doctor);
            return new SuccessResult();
        }
    }
}
