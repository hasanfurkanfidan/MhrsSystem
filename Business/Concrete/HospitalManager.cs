using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Hospital;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HospitalManager : IHospitalService
    {
        private readonly IHospitalDal _hospitalDal;
        private readonly IMapper _mapper;
        public HospitalManager(IHospitalDal hospitalDal, IMapper mapper)
        {
            _hospitalDal = hospitalDal;
            _mapper = mapper;
        }
        public async Task<IResult> CreateHospital(HospitalCreateDto hospitalCreateDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalCreateDto);
            await _hospitalDal.AddAsync(hospital);
            return new SuccessResult();
        }
    }
}
