using Async_Inn.Models.DTOs;
using Async_Inn.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO data)
        {
            try
            {
                await _userService.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return Ok("Done!");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> LogIn([FromBody] RegisterUserDTO userDto)
        {
            try
            {
                var result = await _userService.Authenticate(userDto.Username, userDto.Password);
                if (result == null)
                {
                    return BadRequest("User not found / Password is incorrect!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(userDto);
        }
    }
}
