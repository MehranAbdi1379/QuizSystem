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
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles ="Admin")]
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

        [HttpPost]
        [Route("GetById")]
        [Authorize(Roles ="Student")]
        public async Task<IActionResult> GetById(UserIdStringDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Student unaccept modelstate error");
                return BadRequest(ModelState);

            }
            Log.Information($"Student get by id is completed for student: {dto.Id}");
            return Ok(await studentService.GetStudentById(dto));

        }
    }
}