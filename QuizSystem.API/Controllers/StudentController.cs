using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        [Route("Create-Student")]
        public IActionResult CreateStudent(StudentCreateDTO dto)
        {
            return Ok(studentService.CreateStudent(dto));
        }

        [HttpPost]
        [Route("Accept-Student")]
        public IActionResult AcceptStudent(StudentAcceptDTO dto)
        {
            return Ok(studentService.AcceptStudent(dto));
        }

        [HttpPost]
        [Route("Update-Student")]
        public IActionResult UpdateStudent(StudentUpdateDTO dto)
        {
            return Ok(studentService.UpdateStudent(dto));
        }

        [HttpPost]
        [Route("Change-Student-To-Professor")]
        public IActionResult ChangeStudentToProfessor(StudentIdDTO dto)
        {
            return Ok(studentService.ChangeStudentToProfessor(dto));
        }

        [HttpPost]
        [Route("UnAccept-Student")]
        public IActionResult UnAcceptStudent(StudentAcceptDTO dto)
        {
            return Ok(studentService.UnAcceptStudent(dto));
        }

        [HttpPost]
        [Route("Delete-Student")]
        public IActionResult DeleteStudent(StudentIdDTO dto)
        {
            return Ok(studentService.DeleteStudent(dto));
        }
    }
}