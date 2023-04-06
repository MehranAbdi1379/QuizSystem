using Microsoft.AspNetCore.Mvc;
using QuizSystem.API.Extensions;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/User-Search")]
    public class UserSearchController : ControllerBase
    {
        private readonly IUserSearchService userSearchService;

        public UserSearchController(IUserSearchService userSearchService)
        {
            this.userSearchService = userSearchService;
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
