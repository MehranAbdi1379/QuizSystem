using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class StudentService : IStudentService
    {
        protected readonly IStudentRepository repository;
        protected readonly IProfessorRepository professorRepository;

        public StudentService(IStudentRepository repository , IProfessorRepository professorRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
        }

        public Student CreateStudent(StudentAndProfessorCreateDTO dto)
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

        

        public Student RemoveStudent(StudentAndProfessorIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            repository.Delete(student);
            repository.Save();

            return student;
        }

        public Student UpdateStudent(StudentAndProfessorUpdateDTO dto)
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

        public Student AcceptStudent(StudentAndProfessorIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.SetAccepted(true);

            repository.Update(student);
            repository.Save();

            return student;
        }

        public Student UnAcceptStudent(StudentAndProfessorIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.SetAccepted(false);

            repository.Update(student);
            repository.Save();

            return student;
        }

        public Professor ChangeStudentToProfessor(StudentAndProfessorIdDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            Professor professor = new Professor(student.FirstName,student.LastName,student.NationalCode,student.Password,student.BirthDate,professorRepository);

            repository.Delete(student);
            repository.Save();

            professorRepository.Create(professor);
            professorRepository.Save();

            return professor;
        }
    }
}