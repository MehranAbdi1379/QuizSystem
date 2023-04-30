using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Student")]
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
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetById(UserIdStringDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Student get by id modelstate error");
                return BadRequest(ModelState);

            }
            Log.Information($"Student get by id is completed for student: {dto.Id}");
            return Ok(await studentService.GetStudentById(dto));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllStudents()
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Student get all modelstate error");
                return BadRequest(ModelState);

            }
            Log.Information($"Student get all is successful");
            return Ok(await studentService.GetAllStudents());
        }
    }
}