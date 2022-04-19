using Core.Utilities.Results;
using Entities.Dtos.User;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto);
        Task<IResult> CreateUser(CreateUserDto createUserDto);
        Task<IDataResult<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);
        Task<IDataResult<string>> GetClaim(string accessToken, string claimType);
    }
}
