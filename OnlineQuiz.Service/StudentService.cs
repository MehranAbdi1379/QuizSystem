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

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public Student CreateStudent(CreateStudentDTO dto)
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

        public Student AcceptStudent(StudentAcceptDTO dto)
        {
            Student student = repository.GetWithId(dto.Id);

            student.Accepted = true;

            repository.Update(student);

            return student;
        }
    }
}