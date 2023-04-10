using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpPatch]
        [Route("Accept")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            return Ok(professorService.AcceptProfessor(dto));
        }

        [HttpPatch]
        [Route("UnAccept")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            return Ok(professorService.UnAcceptProfessor(dto));
        }
    }
}