using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;

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
        [Authorize(Roles ="admin")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            if(!ModelState.IsValid)
            {
                Log.Error("Student accept modelstate error.");
                return BadRequest(ModelState);
                
            }
            Log.Information($"Student with if of {dto.Id} is accepted");
            return Ok(studentService.AcceptStudent(dto));
            
        }

        [HttpPatch]
        [Route("UnAccept")]
        [Authorize(Roles ="admin")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Student unaccept modelstate error");
                return BadRequest(ModelState);
                
            }
            Log.Information($"Student with id of {dto.Id} is unaccepted");
            return Ok(studentService.UnAcceptStudent(dto));
            
        }
    }
}