using Microsoft.AspNetCore.Mvc;
using QuizSystem.API.Extensions;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/user-search")]
    public class UserSearchController : ControllerBase
    {
        private readonly IUserSearchService userSearchService;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorRepository;

        public UserSearchController(IUserSearchService userSearchService, IStudentService studentService, IProfessorService professorService)
        {
            this.userSearchService = userSearchService;
            this.studentService = studentService;
            this.professorRepository = professorService;
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

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(2);
        }
    }
}
