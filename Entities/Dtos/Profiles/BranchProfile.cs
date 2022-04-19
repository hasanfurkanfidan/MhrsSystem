using AutoMapper;
using Entities.Dtos.Branch;

namespace Entities.Dtos.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<BranchCreateDto, Entities.Concrete.Branch>();
        }
    }
}
