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
        public IActionResult CreateStudent(CreateStudentDTO dto)
        {
            return Ok(studentService.CreateStudent(dto));
        }

        [HttpPost]
        [Route("Accept-Student")]
        public IActionResult AcceptStudent(StudentAcceptDTO dto)
        {
            return Ok(studentService.AcceptStudent(dto));
        }
    }
}
