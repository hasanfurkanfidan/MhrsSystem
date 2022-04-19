using Business.Abstract;
using Business.Constants;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
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
        private readonly ITokenHelper _tokenHelper;
        private readonly RoleManager<Role> _roleManager;
        public AuthManager(UserManager<User> userManager, ITokenHelper tokenHelper, RoleManager<Role> roleManager)
        {
            _tokenHelper = tokenHelper;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task<IResult> CreateUser(CreateUserDto createUserDto)
        {
            var user = await _userManager.FindByNameAsync(createUserDto.UserName);
            if (user != null)
                return new ErrorResult(Messages.UserExist);

            user = await _userManager.FindByEmailAsync(createUserDto.UserName);
            if (user != null)
                return new ErrorResult(Messages.UserExist);

            user = new User
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);
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

        public async Task<IDataResult<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user == null)
                return new ErrorDataResult<LoginResponseDto>(Messages.EmailOrPasswordInCorrect);

            var passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequestDto.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return new ErrorDataResult<LoginResponseDto>(Messages.EmailOrPasswordInCorrect);

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = _tokenHelper.CreateToken(new Core.Entities.JwtAuthUser
            {
                Email = user.Email,
                Username = user.UserName,
                Roles = userRoles.ToList(),
                UserId = user.Id
            });
            var loginResponseDto = new LoginResponseDto
            {
                AccessToken = token.Token,
                Roles = userRoles.ToList()
            };
            return new SuccessDataResult<LoginResponseDto>(loginResponseDto);
        }
    }
}
