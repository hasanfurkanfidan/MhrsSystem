using Business.Abstract;
using Business.Constants;
using Core.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<User> _userManager;
        public AuthManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto)
        {
            var user = await _userManager.FindByNameAsync(createAdminUserDto.UserName);
            if (user != null)
                return new ErrorResult(Messages.UserExist);

            user = await _userManager.FindByEmailAsync(createAdminUserDto.UserName);
            if (user != null)
                return new ErrorResult(Messages.UserExist);

            user = new User
            {
                UserName = createAdminUserDto.UserName,
                Email = createAdminUserDto.Email,
                PhoneNumber = createAdminUserDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, createAdminUserDto.Password);
            if (!result.Succeeded)
            {
                var errors = String.Join(",", result.Errors.Select(p => p.Description).ToArray());
                return new ErrorResult(errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, EntityConstants.Roles.Admin);
            if (!roleResult.Succeeded)
            {
                var errors = String.Join(",", roleResult.Errors.Select(p => p.Description).ToArray());
                return new ErrorResult(errors);
            }

            return new SuccessResult();
        }
    }
}
