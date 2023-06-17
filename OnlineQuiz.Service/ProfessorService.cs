using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizSystem.Service.Exceptions;
using QuizSystem.Repository;
using Microsoft.AspNetCore.Identity;

namespace QuizSystem.Service
{
    public class ProfessorService : IProfessorService
    {
        protected readonly IProfessorRepository repository;
        protected readonly ICourseRepository courseRepository;
        protected readonly IStudentRepository studentRepository;
        protected readonly UserManager<ApiUser> userManager;

        public ProfessorService(IProfessorRepository repository, ICourseRepository courseRepository, IStudentRepository studentRepository , UserManager<ApiUser> userManager)
        {
            this.repository = repository;
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
            this.userManager = userManager;
        }

        public Professor Create(Guid id)
        {
            var professor = new Professor(id);

            repository.Create(professor);
            repository.Save();

            return professor;
        }

        public Professor Remove(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            repository.Delete(professor);
            repository.Save();

            return professor;
        }

        public Professor Accept(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            professor.SetAccepted(true);

            repository.Update(professor);
            repository.Save();

            return professor;
        }

        public Professor UnAccept(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            professor.SetAccepted(false);

            repository.Update(professor);
            repository.Save();

            return professor;
        }

        public void ChangeProfessorToStudent(UserIdDTO dto)
        {
                Professor professor = repository.GetWithId(dto.Id);
                Student student = new Student(dto.Id);

            studentRepository.Create(student);
            studentRepository.Save();

                repository.Delete(professor);
                repository.Save();
        }

        public async Task<ProfessorGetDTO> GetById(UserIdStringDTO dto)
        {
            var data = await userManager.FindByIdAsync(dto.Id);
            var courses = courseRepository.GetByProfessorId(Guid.Parse(dto.Id));
            var courseIds = new List<Guid>();
            foreach (var item in courses)
            {
                courseIds.Add(item.Id);
            }
            return new ProfessorGetDTO()
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

        public async Task<List<ProfessorGetDTO>> GetAll()
        {
            var data = await userManager.GetUsersInRoleAsync("Professor");
            var professors = new List<ProfessorGetDTO>();

            foreach (var professor in data)
            {
                var courses = courseRepository.GetByProfessorId(Guid.Parse(professor.Id));
                var courseIds = new List<Guid>();
                foreach (var item in courses)
                {
                    courseIds.Add(item.Id);
                }
                professors.Add(new ProfessorGetDTO
                {
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    Accepted = repository.GetWithId(Guid.Parse(professor.Id)).Accepted,
                    BirthDate = professor.BirthDate,
                    NationalCode = professor.NationalCode,
                    Id = Guid.Parse(professor.Id),
                    CourseIds = courseIds
                });
            }
            return professors;
        }
    }
}