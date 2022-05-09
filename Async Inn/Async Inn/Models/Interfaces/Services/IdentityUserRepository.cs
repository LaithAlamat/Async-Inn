using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces.Services
{
    public class IdentityUserRepository : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        public IdentityUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    UserDTO userDto = new UserDTO
                    {
                        Id = user.Id,
                        Username = user.UserName,
                    };
                    return userDto;
                }
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            // throw new NotImplementedException();
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                  error.Code.Contains("Password") ? nameof(data.Password) :
                  error.Code.Contains("Email") ? nameof(data.Email) :
                  error.Code.Contains("UserName") ? nameof(data.Username) :
                  "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

       
    }
}
