using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FAQs.Business.Services;
using FAQs.Data.DTOs;
using FAQs.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FAQs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userDto.Roles);
            
            return Accepted();
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            // _logger.LogInformation($"Login Attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDto))
                {
                    return Unauthorized();
                }

                return Accepted(new {Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        // [Authorize(Roles = "Administrator")]
        // [HttpGet]
        // public async Task<IActionResult> GetAllUsers()
        // {
        //     var users = _userManager.Users;
        //     if (users is null)
        //     {
        //         return NoContent();
        //     }
        //     
        //     var usersDto = _mapper.Map<List<GetUsersDto>>(users);
        //     
        //     return Ok(usersDto);
        // }
    }
}
