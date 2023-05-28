using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class ExamStudentService : IExamStudentService
    {
        protected readonly IExamStudentRepository repository;
        protected readonly IStudentRepository studentRepository;
        protected readonly IExamRepository examRepository;

        public ExamStudentService(IStudentRepository studentRepository, IExamRepository examRepository, IExamStudentRepository repository)
        {
            this.studentRepository = studentRepository;
            this.examRepository = examRepository;
            this.repository = repository;
        }


        public ExamStudent Create(ExamStudentCreateDTO dto)
        {
            var examStudent = new ExamStudent(dto.ExamId, dto.StudentId, 0, examRepository.GetWithId(dto.ExamId).Time, examRepository, studentRepository);

            repository.Create(examStudent);
            repository.Save();

            return examStudent;
        }

        public ExamStudent UpdateGrade(ExamStudentAddGradeDTO dto)
        {
            var examStudent = repository.GetWithId(dto.Id);
            examStudent.Grade = examStudent.Grade + dto.Grade;

            repository.Update(examStudent);
            repository.Save();

            return examStudent;
        }

        public ExamStudent CountDownTimeLeft(IdDTO dto)
        {
            var examStudent = repository.GetWithId(dto.Id);
            examStudent.TimeLeft = examStudent.TimeLeft - 1;

            repository.Update(examStudent);
            repository.Save();

            return examStudent;
        }

        public ExamStudent FinishExam(IdDTO dto)
        {
            var examStudent = repository.GetWithId(dto.Id);
            examStudent.TimeLeft = 0;

            repository.Update(examStudent);
            repository.Save();

            return examStudent;
        }

        public void Delete(IdDTO dto)
        {
            var examStudent = repository.GetWithId(dto.Id);

            repository.Delete(examStudent);
            repository.Save();
        }
    }
}
