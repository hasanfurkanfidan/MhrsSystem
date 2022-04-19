using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Branch;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IBranchDal _branchDal;
        public BranchManager(IMapper mapper, IBranchDal branchDal)
        {
            _mapper = mapper;
            _branchDal = branchDal;
        }
        public async Task<IResult> Create(BranchCreateDto branchCreateDto)
        {
            var branch = _mapper.Map<Branch>(branchCreateDto);
            await _branchDal.AddAsync(branch);
            return new SuccessResult();
        }
    }
}
