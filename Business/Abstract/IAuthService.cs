using Core.Utilities.Results;
using Entities.Dtos.User;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto);
    }
}
