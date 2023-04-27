using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Course")]
    [Authorize(Roles = "Admin")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService= courseService;
        }

        
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCourse(CourseCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Course create modelstate error");
                return BadRequest(ModelState);
                
            }
            Log.Information($"A new course is created with the title of {dto.Title}.");
            return Ok(courseService.CreateCourse(dto));
            
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateCourse(CourseUpdateDTO dto)
        {
            if(!ModelState.IsValid)
            {
                Log.Error("Course update modelstate error.");
                return BadRequest(ModelState);
                
            }
            Log.Information($"Course with id of {dto.Id} is updated");
            return Ok(courseService.UpdateCourse(dto));
            
        }

        [HttpPatch]
        [Route("Add-Student-To-Course")]
        public IActionResult AddStudentToCourse(CourseAndStudentIdDTO dto)
        {
            if(!ModelState.IsValid)
            {
                Log.Error("Course add student modelstate error.");
                return BadRequest(ModelState);
                
            }
            Log.Information($"student with id of {dto.StudentId} added to the course with id of {dto.CourseId}");
            return Ok(courseService.AddStudentToCourse(dto));
            
        }
    }
}
