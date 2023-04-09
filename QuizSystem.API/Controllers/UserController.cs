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
        private readonly IUserSearchService userSearchService;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        private readonly IAdminService adminService;
        private readonly UserManager<ApiUser> userManager;

        public UserController(IUserSearchService userSearchService , IStudentService studentService , IProfessorService professorService , IAdminService adminService , UserManager<ApiUser> userManager)
        {
            this.userSearchService = userSearchService;
            this.studentService = studentService;
            this.professorService = professorService;
            this.adminService = adminService;
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

            var mappercongif = new MapperConfiguration(config => config.CreateMap<UserCreateDTO, ApiUser>());
            var mapper = mappercongif.CreateMapper();
            var user = mapper.Map<ApiUser>(dto);
            user.UserName = dto.NationalCode;

            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, dto.Roles);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult SearchUser(StudentProfessorSearchDTO dto)
        {
            switch (dto.Type.ToLower())
            {
                case "student":
                    Log.Information("Search successful for student");
                    return Ok(userSearchService.SearchForUser(dto).Students);
                case "professor":
                    return Ok(userSearchService.SearchForUser(dto).Professors);
                case "all":
                    return Ok(userSearchService.SearchForUser(dto));
                default:
                    throw new UserSearchTypeInvalidException(); 
            }
        }

        [HttpPost]
        [Route("Sign-In")]
        public IActionResult SignUserIn(UserSignInDTO dto)
        {
            switch(dto.Type.ToLower())
            {
                case "student":
                    return Ok(studentService.StudentSignIn(dto));
                case "professor":
                    return Ok(professorService.ProfessorSignIn(dto));
                case "admin":
                    return Ok(adminService.AdminSignIn(dto));
                default:
                    throw new UserSearchTypeInvalidException(); 
            }
        }
    }
}
