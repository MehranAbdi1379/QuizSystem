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

        [HttpPatch]
        [Route("Accept")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            return Ok(studentService.AcceptStudent(dto));
        }

        [HttpPatch]
        [Route("UnAccept")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            return Ok(studentService.UnAcceptStudent(dto));
        }
    }
}