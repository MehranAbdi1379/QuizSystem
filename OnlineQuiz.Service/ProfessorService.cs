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

namespace QuizSystem.Service
{
    public class ProfessorService : IProfessorService
    {
        protected readonly IUserRepository<Professor> repository;
        protected readonly IUserRepository<Student> studentRepository;
        protected readonly ICourseRepository courseRepository;

        public ProfessorService(IUserRepository<Professor> repository , IUserRepository<Student> studentRepository, ICourseRepository courseRepository)
        {
            this.repository = repository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        public Professor CreateProfessor(UserCreateDTO dto)
        {
            var professor = new Professor(dto.FirstName,
                dto.LastName,
                dto.NationalCode,
                dto.Password,
                dto.BirthDate,
                repository);

            repository.Create(professor);
            repository.Save();

            return professor;
        }

        public StudentAndProfessorSignedInDTO ProfessorSignIn(UserSignInDTO dto)
        {
            try
            {
                var professor = repository.GetWithNationalCodeAndPassword(dto.NationalCode, dto.Password);
                return new StudentAndProfessorSignedInDTO()
                {
                    Id = professor.Id,
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    NationalCode = professor.NationalCode,
                    Password = professor.Password,
                    BirthDate = professor.BirthDate,
                    Courses = courseRepository.GetWithProfessorId(professor.Id)
                };
            }
            catch (Exception ex)
            {
                throw new ProfessorSignInWrongNationalCodeOrPasswordException();
            }
        }

        public Professor UpdateProfessor(UserUpdateDTO dto)
        {
            var professor = repository.GetWithId(dto.Id);
            professor.SetFirstName(dto.FirstName);
            professor.SetLastName(dto.LastName);
            professor.SetBirthDate(dto.BirthDate);
            professor.SetPassword(dto.Password);

            repository.Update(professor);
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

        public Student ChangeProfessorToStudent(UserIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);
            Student student = new Student(professor.FirstName, professor.LastName, professor.NationalCode, professor.Password, professor.BirthDate, studentRepository , professor.Accepted);

            studentRepository.Create(student);
            studentRepository.Save();

            repository.Delete(professor);
            repository.Save();

            return student;
        }

        public List<Professor> SearchProfessor(StudentProfessorSearchDTO dto)
        {
            List<Professor> professors = repository.Filter(dto.FirstName,dto.LastName,dto.NationalCode);

            return professors;
        }
    }
}