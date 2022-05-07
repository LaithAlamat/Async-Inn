using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces.Services
{
    public class IdentityUserRepository : IUserService
    {
        public Task<UserDTO> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}
