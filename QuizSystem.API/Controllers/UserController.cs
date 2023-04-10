using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<ApiUser> userManager;

        public UserController(IUserService userSearchService ,UserManager<ApiUser> userManager)
        {
            this.userService = userSearchService;
            this.userManager = userManager;
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

        [HttpPost]
        [Route("Search")]
        public IActionResult SearchUser(StudentProfessorSearchDTO dto)
        {
            return Ok(userService.SearchForUser(dto));
            
        }
    }
}
