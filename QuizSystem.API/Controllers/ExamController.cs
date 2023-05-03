using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service;
using Serilog;

namespace QuizSystem.API.Controllers
{
    [Route("api/Exam")]
    [ApiController]
    [Authorize(Roles ="Professor")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateExam(ExamCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Create exam modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("New exam created");
                return Ok(examService.CreateExam(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }

            
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateExam(ExamUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Update exam modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information($"Exam with id : {dto.Id} updated");
                return Ok(examService.UpdateExam(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
            
        }

        [HttpPost]
        [Route("GetByCourseId")]
        public IActionResult GetExamByCourseId(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Exam get by course id modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information($"Get exams for course with id {dto.Id}");
                return Ok(examService.GetAllExamsByCourseId(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }

            
        }

        [HttpPost]
        [Route("GetById")]
        public IActionResult GetById(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Exam get by id modelstate error");
                return BadRequest(ModelState);
            }

            Log.Information($"Get exam with id {dto.Id} is successful");
            return Ok(examService.GetById(dto));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Exam delete modelstate error");
                return BadRequest(ModelState);
            }

            Log.Information($"Delete exam with id {dto.Id} is successful");
            examService.DeleteExam(dto);
            return Ok();
        }
    }
}
