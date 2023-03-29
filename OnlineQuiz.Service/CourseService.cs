using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service.Contracts.SingleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class CourseService
    {
        protected readonly ICourseRepository repository;
        protected readonly IProfessorRepository professorRepository;

        public CourseService(ICourseRepository repository , IProfessorRepository professorRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
        }

        public Course CreateCourse(CreateCourseDTO dto)
        {
            var course = new Course(dto.Title,
                dto.StartTime,
                dto.EndTime,
                dto.Professor,
                repository);

            repository.Create(course);
            repository.Save();

            return course;
        }

        //public Course ChangeProfessorOfACourse(CourseDTO courseDto,ProfessorDTO professorDto)
        //{
        //    Professor professor = professorRepository.GetProfessorFromNationalCodeAndPassword(professorDto.NationalCode, professorDto.Password);

        //    Course course 
        //}
    }
}
