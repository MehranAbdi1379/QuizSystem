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

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateStudent(UserCreateDTO dto)
        {
            return Ok(professorService.CreateProfessor(dto));
        }

        [HttpPatch]
        [Route("Accept")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            return Ok(professorService.AcceptProfessor(dto));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateStudent(UserUpdateDTO dto)
        {
            return Ok(professorService.UpdateProfessor(dto));
        }

        [HttpPost]
        [Route("Change-Professor-To-Student")]
        public IActionResult ChangeStudentToProfessor(UserIdDTO dto)
        {
            return Ok(professorService.ChangeProfessorToStudent(dto));
        }

        [HttpPatch]
        [Route("UnAccept")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            return Ok(professorService.UnAcceptProfessor(dto));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteStudent(UserIdDTO dto)
        {
            return Ok(professorService.RemoveProfessor(dto));
        }
    }
}
