using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Serilog;

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

        [HttpPatch]
        [Route("Accept")]
        [Authorize(Roles = "Admin")]
        public IActionResult AcceptStudent(UserIdDTO dto)
        {
            if(!ModelState.IsValid)
            {
                Log.Error("Professor accept modelstate error.");
                return BadRequest(ModelState);
                
            }
            Log.Information($"Professor with id of {dto.Id}, is accepted.");
            return Ok(professorService.AcceptProfessor(dto));
            
        }

        [HttpPatch]
        [Route("UnAccept")]
        [Authorize(Roles ="Admin")]
        public IActionResult UnAcceptStudent(UserIdDTO dto)
        {
            if(!ModelState.IsValid)
            {
                Log.Error("Professor unaccept modelstate error.");
                return BadRequest(ModelState);
                
            }
            Log.Information($"Professor with id of {dto.Id} is unaccepted");
            return Ok(professorService.UnAcceptProfessor(dto));
           
        }

        [HttpPost]
        [Route("GetById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(UserIdStringDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Professor get by id modelstate error");
                return BadRequest(ModelState);

            }
            Log.Information($"Professor get by id is completed for student: {dto.Id}");
            return Ok(await professorService.GetProfessorById(dto));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllProfessors()
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Professor get all modelstate error");
                return BadRequest(ModelState);

            }
            Log.Information($"Professor get all is successful");
            return Ok(await professorService.GetAllProfessors());
        }
    }
}