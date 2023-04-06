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
        [Route("Create")]
        public IActionResult CreateStudent(UserCreateDTO dto)
        {
            return Ok(studentService.CreateStudent(dto));
        }

        [HttpPatch]
        [Route("Accept")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            return Ok(studentService.AcceptStudent(dto));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateStudent(UserUpdateDTO dto)
        {
            return Ok(studentService.UpdateStudent(dto));
        }

        [HttpPost]
        [Route("Change-Student-To-Professor")]
        public IActionResult ChangeStudentToProfessor(UserIdDTO dto)
        {
            return Ok(studentService.ChangeStudentToProfessor(dto));
        }

        [HttpPatch]
        [Route("UnAccept")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            return Ok(studentService.UnAcceptStudent(dto));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteStudent(UserIdDTO dto)
        {
            return Ok(studentService.RemoveStudent(dto));
        }
    }
}