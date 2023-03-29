using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizSystem.Service.Contracts.SingleDTO;

namespace QuizSystem.Service
{
    public class StudentService : IStudentService
    {
        protected readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public Student CreateStudent(StudentDTO dto)
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

        public void RemoveStudent(StudentDTO dto)
        {
            Student student = new Student(dto.FirstName,dto.LastName,dto.NationalCode,dto.Password,dto.BirthDate,repository);

            repository.Delete(student);
        }

        public Student AcceptStudent(StudentDTO dto)
        {
            Student student = repository.GetStudentFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

            student.Accepted = true;

            repository.Update(student);

            return student;
        }
    }
}