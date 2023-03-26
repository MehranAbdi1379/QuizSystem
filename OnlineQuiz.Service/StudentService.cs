using OnlineQuiz.Service.Contracts.DTO;
using QuizSystem.Domain;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Service
{
    public class StudentService
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

        public Student RemoveStudent(RemoveStudentDTO dto)
        {
            Student student = repository.GetUserFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

            repository.Delete(student);

            return student;
        }
    }
}