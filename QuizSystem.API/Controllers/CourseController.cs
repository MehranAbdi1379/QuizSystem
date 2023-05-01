using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;
using Serilog;
using System.Diagnostics.Eventing.Reader;

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
            this.courseService = courseService;
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
            
            Log.Information($"Course with id of {dto.Id} is updated");
            return Ok(courseService.UpdateCourse(dto));

        }

        [HttpPatch]
        [Route("AddStudentToCourse")]
        public IActionResult AddStudentToCourse(CourseAndStudentIdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Course add student modelstate error.");
                return BadRequest(ModelState);

            }
            Log.Information($"student with id of {dto.StudentId} added to the course with id of {dto.CourseId}");
            return Ok(courseService.AddStudentToCourse(dto));

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllCourses()
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Get all courses modelstate error");
                return BadRequest(ModelState);
            }

            Log.Information("Get all courses is successful");
            return Ok(courseService.GetAllCourses());
        }

        [HttpPost]
        [Route("GetById")]
        public IActionResult GetWithId(CourseIdStringDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Get course modelstate error");
                return BadRequest(ModelState);
            }

            Log.Information($"Get course {dto.Id} is successful");
            return Ok(courseService.GetCourseById(dto));
        }

        [HttpPost]
        [Route("GetStudentsByCourseId")]
        public IActionResult GetStudentsWithCourseId(CourseIdStringDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Get students with course id modelstate error");
                return BadRequest(ModelState);
            }

            Log.Information($"Get students of course {dto.Id} is successful");
            return Ok(courseService.GetStudentsByCourseId(dto));
        }
    }
}
