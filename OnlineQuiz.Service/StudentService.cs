using QuizSystem.Service.Contracts.DTO;
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
    public class StudentService : IStudentService
    {
        protected readonly IUserRepository<Student> repository;
        protected readonly IUserRepository<Professor> professorRepository;
        protected readonly ICourseStudentRepository courseStudentRepository;

        public StudentService(IUserRepository<Student> repository , IUserRepository<Professor> professorRepository, ICourseStudentRepository courseStudentRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
            this.courseStudentRepository = courseStudentRepository;
        }

        public Student CreateStudent(UserCreateDTO dto)
        {
            var student = new Student(dto.FirstName,
                dto.LastName,
                dto.NationalCode,
                dto.Password,
                dto.BirthDate,
                repository);

            repository.Create(student);
            repository.Save();

            return student;
        }

        public StudentAndProfessorSignedInDTO StudentSignIn(UserSignInDTO dto)
        {
            try
            {
                var student = repository.GetWithNationalCodeAndPassword(dto.NationalCode , dto.Password);
                return new StudentAndProfessorSignedInDTO()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    NationalCode = student.NationalCode,
                    Password = student.Password,
                    BirthDate = student.BirthDate,
                    Courses = courseStudentRepository.GetCourseIds(student.Id)
                };
            }
            catch (StudentSignInWrongNationalCodeOrPasswordException ex)
            {
                throw ex;
            }
        }

        public Student RemoveStudent(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            repository.Delete(student);
            repository.Save();

            return student;
        }

        public Student UpdateStudent(UserUpdateDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.SetFirstName(dto.FirstName);
            student.SetLastName(dto.LastName);
            student.SetNationalCode(dto.NationalCode,repository);
            student.SetBirthDate(dto.BirthDate);

            repository.Update(student);
            repository.Save();

            return student;
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

        public Professor ChangeStudentToProfessor(UserIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            Professor professor = new Professor(student.FirstName,student.LastName,student.NationalCode,student.Password,student.BirthDate,professorRepository , student.Accepted);

            repository.Delete(student);
            repository.Save();

            professorRepository.Create(professor);
            professorRepository.Save();

            return professor;
        }

        public List<Student> SearchStudent(StudentProfessorSearchDTO dto)
        {
            List<Student> students = repository.Filter(dto.FirstName, dto.LastName, dto.NationalCode);

            return students;
        }
    }
}