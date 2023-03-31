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
        public IActionResult CreateStudent(StudentAndProfessorCreateDTO dto)
        {
            return Ok(studentService.CreateStudent(dto));
        }

        [HttpPatch]
        [Route("Accept-Student")]
        public IActionResult AcceptStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(studentService.AcceptStudent(dto));
        }

        [HttpPut]
        [Route("Update-Student")]
        public IActionResult UpdateStudent(StudentAndProfessorUpdateDTO dto)
        {
            return Ok(studentService.UpdateStudent(dto));
        }

        [HttpPost]
        [Route("Change-Student-To-Professor")]
        public IActionResult ChangeStudentToProfessor(StudentAndProfessorIdDTO dto)
        {
            return Ok(studentService.ChangeStudentToProfessor(dto));
        }

        [HttpPatch]
        [Route("UnAccept-Student")]
        public IActionResult UnAcceptStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(studentService.UnAcceptStudent(dto));
        }

        [HttpDelete]
        [Route("Delete-Student")]
        public IActionResult DeleteStudent(StudentAndProfessorIdDTO dto)
        {
            return Ok(studentService.RemoveStudent(dto));
        }
    }
}