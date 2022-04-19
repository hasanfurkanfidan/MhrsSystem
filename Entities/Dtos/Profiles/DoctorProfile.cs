using AutoMapper;
using Entities.Dtos.Doctor;

namespace Entities.Dtos.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorCreateDto, Entities.Concrete.Doctor>();
        }
    }
}
