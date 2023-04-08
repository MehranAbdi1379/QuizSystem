using Microsoft.AspNetCore.Mvc;
using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;

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

        public UserController(IUserSearchService userSearchService , IStudentService studentService , IProfessorService professorService , IAdminService adminService)
        {
            this.userSearchService = userSearchService;
            this.studentService = studentService;
            this.professorService = professorService;
            this.adminService = adminService;
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult SearchUser(StudentProfessorSearchDTO dto)
        {
            switch (dto.Type.ToLower())
            {
                case "student":
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
