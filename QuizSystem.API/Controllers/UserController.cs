using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;
using System.Data;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<ApiUser> userManager;
        private readonly IAuthManager authManager;

        public UserController(IUserService userSearchService , UserManager<ApiUser> userManager, IAuthManager authManager)
        {
            this.userService = userSearchService;
            this.userManager = userManager;
            this.authManager = authManager;
        }

        [HttpPost]
        [Route("Sign-Up")]
        public async Task<IActionResult> SignUp(UserCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await userService.SignUp(dto , userManager);

            if (task.Succeeded)
                return Ok(task);
            return BadRequest(task);
        }

        [Authorize]
        [HttpPost]
        [Route("Search")]
        public IActionResult SearchUser(StudentProfessorSearchDTO dto)
        {
            return Ok(userService.SearchForUser(dto));
            
        }

        [HttpPost]
        [Route("Sign-In")]
        public async Task<IActionResult> SignIn(UserSignInDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await authManager.ValidateUser(dto))
            {
                return Unauthorized();
            }

            return Accepted(new { Token = await authManager.CreateToken() });
        }
    }
}
