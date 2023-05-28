﻿using Microsoft.AspNetCore.Authorization;
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
        [Route("ExamStudent/CreateOrGet")]
        [Authorize(Roles = "Student")]
        public IActionResult CreateOrGetExamStudent(ExamStudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Create examStudent modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("New examStudent created");
                return Ok(examStudentService.CreateOrGet(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPatch]
        [Route("ExamStudent/UpdateGrade")]
        [Authorize(Roles = "Student")]
        public IActionResult UpdateExamStudentGrade(ExamStudentAddGradeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Update examStudent Grade modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("Update examStudent Grade was successful");
                return Ok(examStudentService.UpdateGrade(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPatch]
        [Route("ExamStudent/UpdateTimeLeft")]
        [Authorize(Roles = "Student")]
        public IActionResult ExamStudentCountDownTimeLeft(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Update examStudent time left modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("Update examStudent time left was successful");
                return Ok(examStudentService.CountDownTimeLeft(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPatch]
        [Route("ExamStudent/FinishExam")]
        [Authorize(Roles = "Student")]
        public IActionResult ExamStudentFinishExam(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Finish examStudent modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("Finish examStudent was successful");
                return Ok(examStudentService.FinishExam(dto));
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
        [Authorize(Roles = "Student,Professor")]
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
        [Route("ExamStudentQuestion/CreateOrGet")]
        [Authorize(Roles = "Student")]
        public IActionResult CreateOrGetExamStudentQuestion(ExamStudentQuestionCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Create examStudentQuestion modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("New examStudentQuestion created");
                return Ok(examStudentService.CreateOrGetQuestion(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPatch]
        [Route("ExamStudentQuestion/Update")]
        [Authorize(Roles = "Student")]
        public IActionResult UpdateExamStudentQuestion(ExamStudentAddGradeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Update examStudentQuestion modelstate error");
                return BadRequest(ModelState);
            }

            try
            {
                Log.Information("Update examStudentQuestion was successful");
                return Ok(examStudentService.UpdateGrade(dto));
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
