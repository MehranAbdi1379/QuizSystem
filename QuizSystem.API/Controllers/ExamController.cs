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
    
    public class ExamController : ControllerBase
    {
        private readonly IExamService examService;
        private readonly IExamStudentService examStudentService;

        public ExamController(IExamService examService, IExamStudentService examStudentService)
        {
            this.examService = examService;
            this.examStudentService = examStudentService;
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Professor")]
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
        [Authorize(Roles = "Professor")]
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
        [Authorize(Roles ="Student,Professor")]
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
        [Authorize(Roles = "Student,Professor")]
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

        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Professor")]
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

        [HttpPost]
        [Route("ExamStudent/Create")]
        [Authorize(Roles = "Student")]
        public IActionResult CreateExamStudent(ExamStudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Create examStudent modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("New examStudent created");
                return Ok(examStudentService.Create(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPost]
        [Route("ExamStudent/Get")]
        [Authorize(Roles = "Student")]
        public IActionResult GetExamStudent(ExamStudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Get examStudent modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("Get examStudent successful");
                return Ok(examStudentService.GetByStudentAndExamId(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPost]
        [Route("ExamStudent/Exist")]
        [Authorize(Roles = "Student")]
        public IActionResult ExamStudentExist(ExamStudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("ExamStudentExist modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("ExamStudentExist successful");
                return Ok(examStudentService.StudentExamExist(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpDelete]
        [Route("ExamStudent/Delete")]
        [Authorize(Roles = "Professor")]
        public IActionResult DeleteExamStudent(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("ExamStudent delete modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information($"Delete examStudent with id {dto.Id} is successful");
                examStudentService.Delete(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }

            
        }

        [HttpPost]
        [Route("ExamStudent/Finished")]
        [Authorize(Roles = "Student")]
        public IActionResult ExamStudentFinished(ExamStudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("ExamStudentFinished modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("ExamStudentFinished successful");
                return Ok(examStudentService.isExamFinished(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPost]
        [Route("ExamStudent/GetAllByExamId")]
        [Authorize(Roles = "Professor")]
        public IActionResult ExamStudentGetAllByExamId(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("ExamStudentGetAllByExamId modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("ExamStudentGetAllByExamId is successful");
                return Ok(examStudentService.GetAllByExamId(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }
    }
}
