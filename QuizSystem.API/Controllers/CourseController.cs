﻿using Microsoft.AspNetCore.Mvc;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService= courseService;
        }

        [HttpPost]
        [Route("Create-Course")]
        public IActionResult CreateCourse(CourseCreateDTO dto)
        {
            return Ok(courseService.CreateCourse(dto));
        }

        [HttpPut]
        [Route("Update-Course")]
        public IActionResult UpdateCourse(CourseUpdateDTO dto)
        {
            return Ok(courseService.UpdateCourse(dto));
        }

        [HttpPatch]
        [Route("Add-Student-To-Course")]
        public IActionResult AddStudentToCourse(CourseAndStudentIdDTO dto)
        {
            return Ok(courseService.AddStudentToCourse(dto));
        }
    }
}