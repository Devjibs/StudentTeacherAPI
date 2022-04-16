using Microsoft.AspNetCore.Identity;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Service.Interfaces;

public interface IUserAuthenticationRepository
{
    Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
    Task<bool> ValidateUserAsync(UserLoginDto loginDto); 
    Task<string> CreateTokenAsync(); 
}

