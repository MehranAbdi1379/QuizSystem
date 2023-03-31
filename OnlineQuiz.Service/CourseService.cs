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

        public CourseService(ICourseRepository repository, IProfessorRepository professorRepository, IStudentRepository studentRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
            this.studentRepository = studentRepository;
        }

        public Course CreateCourse(CourseCreateDTO dto)
        {
            List<Student> students = new List<Student>();

            foreach (var item in dto.StudentIds)
            {
                students.Add(studentRepository.GetWithId(item));
            }

            var course = new Course(dto.Title,
                dto.StartTime,
                dto.EndTime,
                repository,
                students,
                dto.ProfessorId,
                professorRepository);

            repository.Create(course);
            repository.Save();

            return course;
        }

        public Course UpdateCourse(CourseUpdateDTO dto)
        {
            List<Student> students = new List<Student>();

            foreach (var item in dto.StudentIds)
            {
                students.Add(studentRepository.GetWithId(item));
            }

            Course course = repository.GetWithId(dto.Id);

            course.SetTime(dto.StartTime, dto.EndTime);
            course.SetTitle(dto.Title, repository);
            course.SetStudents(students);
            course.SetProfessor(dto.ProfessorId, professorRepository);

            repository.Update(course);
            repository.Save();

            return course;
        }

        public Course AddStudentToCourse(CourseAndStudentIdDTO dto)
        {
            Student student = studentRepository.GetWithId(dto.StudentId);
            Course course = repository.GetWithId(dto.CourseId);

            course.AddStudent(student, studentRepository);

            repository.Update(course);
            repository.Save();

            return course;
        }
    }
}