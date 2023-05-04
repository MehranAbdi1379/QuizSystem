using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;

namespace QuizSystem.API.Controllers
{
    [Route("api/Question")]
    [ApiController]
    [Authorize(Roles =("Professor"))]
    public class QuestionController : ControllerBase
    {
        private readonly IMultipleChoiceQuestionService multipleChoiceQuestionService;
        private readonly IDescriptiveQuestionService descriptiveQuestionService;
        private readonly IGradedQuestionService gradedQuestionService;
        public QuestionController(IDescriptiveQuestionService descriptiveQuestionService, IMultipleChoiceQuestionService multipleChoiceQuestionService, IGradedQuestionService gradedQuestionService)
        {
            this.descriptiveQuestionService = descriptiveQuestionService;
            this.multipleChoiceQuestionService = multipleChoiceQuestionService;
            this.gradedQuestionService = gradedQuestionService;
        }
        [HttpPost]
        [Route("Descriptive/Create")]
        public IActionResult CreateDescriptiveQuestion(QuestionCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Descriptive question create modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Descriptive question create successful");
                return Ok(descriptiveQuestionService.Create(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
                
        }

        [HttpPut]
        [Route("Descriptive/Update")]
        public IActionResult UpdateDescriptiveQuestion(QuestionUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Descriptive question update modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Descriptive question with id: {dto.Id} update successful");
                return Ok(descriptiveQuestionService.Update(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpDelete]
        [Route("Descriptive/Delete")]
        public IActionResult DeleteDescriptiveQuestion(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Descriptive question delete modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Descriptive question with id: {dto.Id} delete successful");
                descriptiveQuestionService.Delete(dto);
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
        [Route("Descriptive/GetByCourseAndProfessorId")]
        public IActionResult GetDescriptiveQuestionByCourseAndProfessorId(CourseAndProfessorIdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Descriptive question getByCourseAndProfessorId modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Descriptive question getByCourseAndProfessorId successful");
                return Ok(descriptiveQuestionService.GetWithCourseAndProfessorId(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPost]
        [Route("MultipleChoice/Create")]
        public IActionResult CreateMultipleChoiceQuestion(QuestionCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Multiple choice question create modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Multiple choice question create successful");
                return Ok(multipleChoiceQuestionService.Create(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPut]
        [Route("MultipleChoice/Update")]
        public IActionResult UpdateMultipleChoiceQuestion(QuestionUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("MultipleChoice question update modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"MultipleChoice question update successful");
                return Ok(multipleChoiceQuestionService.Update(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpDelete]
        [Route("MultipleChoice/Delete")]
        public IActionResult DeleteMultipleChoiceQuestion(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("MultipleChoice question delete modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"MultipleChoice question delete successful");
                multipleChoiceQuestionService.Delete(dto);
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
        [Route("MultipleChoice/GetByCourseAndProfessorId")]
        public IActionResult GetMultipleChoiceQuestionByCourseAndProfessorId(CourseAndProfessorIdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("MultipleChoice question GetByCourseAndProfessorId modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"MultipleChoice question GetByCourseAndProfessorId successful");
                return Ok(multipleChoiceQuestionService.GetWithCourseAndProfessorId(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpPost]
        [Route("MultipleChoice/Answer/Create")]
        public IActionResult CreateMultipleChoiceAnswer(MultipleChoiceAnswerCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("MultipleChoice answer create modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"MultipleChoice answer create successful");
                return Ok(multipleChoiceQuestionService.CreateAnswer(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpDelete]
        [Route("MultipleChoice/Answer/Delete")]
        public IActionResult DeleteMultipleChoiceAnswer(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("MultipleChoice answer delete modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"MultipleChoice answer delete successful");
                multipleChoiceQuestionService.DeleteAnswer(dto);
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
        [Route("GradedQuestion/Create")]
        public IActionResult CreateGradedQuestion(GradedQuestionCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Graded question create modelstate error.");
                return BadRequest(ModelState);

            }
            try
            {
                Log.Information($"Graded question create successful");
                return Ok(gradedQuestionService.Create(dto));
            }
            catch (Exception ex)
            {
                var errorObject = new ObjectResult(ex.Message);
                errorObject.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObject;
            }
        }

        [HttpDelete]
        [Route("GradedQuestion/Delete")]
        public IActionResult DeleteGradedQuestion(IdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Graded question delete modelstate error.");
                return BadRequest(ModelState);
            }
            try
            {
                Log.Information($"Graded question delete successful");
                gradedQuestionService.Delete(dto);
                return Ok();
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
