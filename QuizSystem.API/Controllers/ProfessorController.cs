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
        [Route("Create-Professor")]
        public IActionResult CreateStudent(StudentAndProfessorCreateDTO dto)
        {
            return Ok(professorService.CreateProfessor(dto));
        }

        [HttpPost]
        [Route("Accept-Professor")]
        public IActionResult AcceptStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(professorService.AcceptProfessor(dto));
        }

        [HttpPost]
        [Route("Update-Professor")]
        public IActionResult UpdateStudent(StudentAndProfessorUpdateDTO dto)
        {
            return Ok(professorService.UpdateProfessor(dto));
        }

        [HttpPost]
        [Route("Change-Professor-To-Student")]
        public IActionResult ChangeStudentToProfessor(StudentAndProfessorIdDTO dto)
        {
            return Ok(professorService.ChangeProfessorToStudent(dto));
        }

        [HttpPost]
        [Route("UnAccept-Professor")]
        public IActionResult UnAcceptStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(professorService.UnAcceptProfessor(dto));
        }

        [HttpPost]
        [Route("Delete-Professor")]
        public IActionResult DeleteStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(professorService.RemoveProfessor(dto));
        }
    }
}
