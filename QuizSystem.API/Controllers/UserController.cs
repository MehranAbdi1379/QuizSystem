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
                Log.Error("sign up modelstate error.");
                return BadRequest(ModelState);
            }
            if(dto.Role.ToLower() != "admin")
            {
                var task = await userService.SignUp(dto, userManager);

                if (task.Succeeded)
                {
                    Log.Information($"New user with national code of {dto.NationalCode} is signed up.");
                    return Ok(task);
                    
                }

                Log.Error("User can not be signed up.");
                return BadRequest(task);
            }
            Log.Error("Admin can only be added in development phase");
            return BadRequest("Admin can only be added in development phase");
            
        }

        [HttpPost]
        [Route("Search")]
        [Authorize(Roles = "admin")]
        public IActionResult SearchUser(StudentProfessorSearchDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Log.Information("User search finished.");
            return Ok(userService.SearchForUser(dto));
        }

        [HttpPost]
        [Route("Sign-In")]
        public async Task<IActionResult> SignIn(UserSignInDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Sign in modelstate error.");
                return BadRequest(ModelState);
            }

            if(!await authManager.ValidateUser(dto))
            {
                Log.Warning("NationalCode or Password is wrong. Can not sign in.");
                return Unauthorized();
            }
            Log.Information($"User with national code of {dto.NationalCode} is signed in");
            return Accepted(new { Token = await authManager.CreateToken() });
        }
    }
}
