using AutoMapper;
using Entities.Dtos.Hospital;

namespace Entities.Dtos.Profiles
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<HospitalCreateDto, Entities.Concrete.Hospital>();
        }
    }
}
