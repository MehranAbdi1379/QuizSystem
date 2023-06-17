using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizSystem.Service.Exceptions;
using QuizSystem.Repository;
using QuizSystem.Repository.DataBase;
using Microsoft.AspNetCore.Identity;

namespace QuizSystem.Service
{
    public class StudentService : IStudentService
    {
        protected readonly ICourseStudentRepository courseStudentRepository;
        protected readonly IStudentRepository repository;
        protected readonly IProfessorRepository professorRepository;
        protected readonly UserManager<ApiUser> userManager;

        public StudentService(ICourseStudentRepository courseStudentRepository , IStudentRepository studentRepository, IProfessorRepository professorRepository , UserManager<ApiUser> userManager)
        {
            this.courseStudentRepository = courseStudentRepository;
            repository = studentRepository;
            this.professorRepository = professorRepository;
            this.userManager = userManager;
        }

        public Student CreateStudent(Guid id)
        {
            var student = new Student(id);

            repository.Create(student);
            repository.Save();

            return student;
        }

        public void RemoveStudent(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            foreach (var item in courseStudentRepository.GetByStudentId(dto.Id))
            {
                courseStudentRepository.Delete(item);
            }

            courseStudentRepository.Save();
            repository.Delete(student);
            repository.Save();
        }

        public Student AcceptStudent(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.SetAccepted(true);

            repository.Update(student);
            repository.Save();

            return student;
        }

        public Student UnAcceptStudent(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.SetAccepted(false);

            repository.Update(student);
            repository.Save();

            return student;
        }

        public void ChangeStudentToProfessor(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);
            var professor = new Professor(dto.Id);

            professorRepository.Create(professor);
            professorRepository.Save();

            repository.Delete(student);
            repository.Save();

            foreach (var item in courseStudentRepository.GetByStudentId(dto.Id))
            {
                courseStudentRepository.Delete(item);
            }

            courseStudentRepository.Save();
        }

        public async Task<StudentGetDTO> GetStudentById(UserIdStringDTO dto)
        {
            var data = await userManager.FindByIdAsync(dto.Id);
            var courses = courseStudentRepository.GetByStudentId(Guid.Parse(dto.Id));
            var courseIds = new List<Guid>();
            foreach (var item in courses)
            {
                courseIds.Add(item.CourseId);
            }
            return new StudentGetDTO()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Accepted = repository.GetWithId(Guid.Parse(dto.Id)).Accepted,
                BirthDate = data.BirthDate,
                NationalCode = data.NationalCode,
                Id = Guid.Parse(dto.Id),
                CourseIds = courseIds
            };
        }

        public async Task<List<StudentGetDTO>> GetAllStudents()
        {
            var data = await userManager.GetUsersInRoleAsync("Student");
            var students = new List<StudentGetDTO>();

            foreach (var student in data)
            {
                var courses = courseStudentRepository.GetByStudentId(Guid.Parse(student.Id));
                var courseIds = new List<Guid>();
                foreach (var item in courses)
                {
                    courseIds.Add(item.CourseId);
                }
                students.Add(new StudentGetDTO
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Accepted = repository.GetWithId(Guid.Parse(student.Id)).Accepted,
                    BirthDate = student.BirthDate,
                    NationalCode = student.NationalCode,
                    Id = Guid.Parse(student.Id),
                    CourseIds = courseIds
                });
            }
            return students;
        }
    }
}