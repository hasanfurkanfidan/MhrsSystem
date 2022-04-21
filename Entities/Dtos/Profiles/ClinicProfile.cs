using AutoMapper;
using Entities.Dtos.Clinic;

namespace Entities.Dtos.Profiles
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<ClinicCreateDto, Entities.Concrete.Clinic>();
        }
    }
}
