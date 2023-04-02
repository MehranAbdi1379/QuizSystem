using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class CourseService : ICourseService
    {
        protected readonly ICourseRepository repository;
        protected readonly IProfessorRepository professorRepository;
        protected readonly IStudentRepository studentRepository;
        protected readonly ICourseStudentRepository courseStudentRepository;

        public CourseService(ICourseRepository repository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository,
            ICourseStudentRepository courseStudentRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
            this.studentRepository = studentRepository;
        }

        public Guid CreateCourse(CourseCreateDTO dto)
        {
            var course = new Course(dto.Title,
                dto.StartTime,
                dto.EndTime,
                repository,
                dto.StudentIds,
                dto.ProfessorId,
                professorRepository
                ,studentRepository);

            foreach (var studentId in dto.StudentIds)
            {
                CourseStudent courseStudent = new CourseStudent(studentId,course.Id,repository,studentRepository);
                courseStudentRepository.Create(courseStudent);
            }

            courseStudentRepository.Save();
            repository.Create(course);
            repository.Save();

            return course.Id;
        }

        public Guid UpdateCourse(CourseUpdateDTO dto)
        {
            Course course = repository.GetWithId(dto.Id);

            course.SetTime(dto.StartTime, dto.EndTime);
            course.SetTitle(dto.Title, repository);
            course.SetStudents(dto.StudentIds,studentRepository);
            course.SetProfessor(dto.ProfessorId, professorRepository);

            repository.Update(course);
            repository.Save();

            return course.Id;
        }

        public Guid AddStudentToCourse(CourseAndStudentIdDTO dto)
        {
            Course course = repository.GetWithId(dto.CourseId);

            course.AddStudent(dto.StudentId, studentRepository);

            repository.Update(course);
            repository.Save();

            return course.Id;
        }
    }
}