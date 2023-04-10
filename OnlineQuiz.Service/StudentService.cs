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

namespace QuizSystem.Service
{
    public class StudentService : IStudentService
    {
        protected readonly ICourseStudentRepository courseStudentRepository;
        protected readonly IStudentRepository repository;
        protected readonly IProfessorRepository professorRepository;

        public StudentService(ICourseStudentRepository courseStudentRepository , IStudentRepository studentRepository, IProfessorRepository professorRepository)
        {
            this.courseStudentRepository = courseStudentRepository;
            repository = studentRepository;
            this.professorRepository = professorRepository;
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

            foreach (var item in courseStudentRepository.GetWithStudentId(dto.Id))
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

            foreach (var item in courseStudentRepository.GetWithStudentId(dto.Id))
            {
                courseStudentRepository.Delete(item);
            }

            courseStudentRepository.Save();
        }
    }
}