using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class ProfessorService : IProfessorService
    {
        protected readonly IProfessorRepository repository;
        protected readonly IStudentRepository studentRepository;

        public ProfessorService(IProfessorRepository repository , IStudentRepository studentRepository)
        {
            this.repository = repository;
            this.studentRepository = studentRepository;
        }

        public Professor CreateProfessor(StudentAndProfessorCreateDTO dto)
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

        public Professor UpdateProfessor(StudentAndProfessorUpdateDTO dto)
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

        public Professor RemoveProfessor(StudentAndProfessorIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            repository.Delete(professor);
            repository.Save();

            return professor;
        }

        public Professor AcceptProfessor(StudentAndProfessorIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            professor.SetAccepted(true);

            repository.Update(professor);
            repository.Save();

            return professor;
        }

        public Professor UnAcceptProfessor(StudentAndProfessorIdDTO dto)
        {
            Professor professor = repository.GetWithId(dto.Id);

            professor.SetAccepted(false);

            repository.Update(professor);
            repository.Save();

            return professor;
        }

        public Student ChangeProfessorToStudent(StudentAndProfessorIdDTO dto)
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