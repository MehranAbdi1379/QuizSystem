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

namespace QuizSystem.Service
{
    public class ProfessorService : IProfessorService
    {
        protected readonly IProfessorRepository repository;
        protected readonly ICourseRepository courseRepository;
        protected readonly IStudentRepository studentRepository;

        public ProfessorService(IProfessorRepository repository, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            this.repository = repository;
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
        }

        public Professor CreateProfessor(Guid id)
        {
            var professor = new Professor(id);

            repository.Create(professor);
            repository.Save();

            return professor;
        }

        public Professor RemoveProfessor(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            repository.Delete(professor);
            repository.Save();

            return professor;
        }

        public Professor AcceptProfessor(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            professor.SetAccepted(true);

            repository.Update(professor);
            repository.Save();

            return professor;
        }

        public Professor UnAcceptProfessor(UserIdDTO dto)
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
    }
}