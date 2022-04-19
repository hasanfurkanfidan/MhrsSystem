using Core.Utilities.Results;
using Entities.Dtos.Branch;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        Task<IResult> Create(BranchCreateDto branchCreateDto);
    }
}
