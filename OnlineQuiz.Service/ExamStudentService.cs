using Microsoft.VisualBasic;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
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
        protected readonly IGradedQuestionRepository gradedQuestionRepository;
        protected readonly IExamStudentQuestionRepository examStudentQuestionRepository;
        protected readonly IExamStudentRepository examStudentRepository;

        public ExamStudentService(IStudentRepository studentRepository, IExamRepository examRepository, IExamStudentRepository repository, IGradedQuestionRepository gradedQuestionRepository, IExamStudentQuestionRepository examStudentQuestionRepository, IExamStudentRepository examStudentRepository)
        {
            this.studentRepository = studentRepository;
            this.examRepository = examRepository;
            this.repository = repository;
            this.gradedQuestionRepository = gradedQuestionRepository;
            this.examStudentQuestionRepository = examStudentQuestionRepository;
            this.examStudentRepository = examStudentRepository;
        }


        public ExamStudent Create(ExamStudentCreateDTO dto)
        {
            var examStudent = new ExamStudent(dto.ExamId, dto.StudentId, 0, examRepository, studentRepository,examStudentRepository,gradedQuestionRepository);
            var gradedQuestions = gradedQuestionRepository.GetAllByExamId(dto.ExamId);
            repository.Create(examStudent);
            repository.Save();

            foreach (var item in gradedQuestions)
            {
                var examStudentQuestion = new ExamStudentQuestion(examStudent.Id, item.Id, "", repository, gradedQuestionRepository);

                examStudentQuestionRepository.Create(examStudentQuestion);
                
            }
            examStudentQuestionRepository.Save();
            

            return examStudent;
        }

        public bool StudentExamExist(ExamStudentCreateDTO dto)
        {
            return repository.ExamStudentAlreadyExist(dto.ExamId, dto.StudentId);
        }

        public bool isExamFinished(ExamStudentCreateDTO dto)
        {
            var examStudent = repository.GetByExamAndStudentId(dto.ExamId, dto.StudentId);

            var now = DateTime.Now;

            if(now>examStudent.EndTime)
                return true;
            return false;
        }

        public ExamStudent GetByStudentAndExamId(ExamStudentCreateDTO dto)
        {
            return repository.GetByExamAndStudentId(dto.ExamId, dto.StudentId);
        }
        
        public List<ExamStudent> GetAllByExamId(IdDTO dto)
        {
            return repository.GetAllByExamId(dto.Id);
        }

        //public List<Student> GetAllStudentsByExamId(IdDTO dto)
        //{
        //    var examStudents = repository.GetAllByExamId(dto.Id);
        //    var students = new List<Student>();

        //    foreach (var item in examStudents)
        //    {
        //        students.Add(studentRepository.GetWithId(item.StudentId));
        //    }
        //}

        public ExamStudent UpdateGrade(IdDTO dto)
        {
            var examStudent = repository.GetWithId(dto.Id);
            var questions = examStudentQuestionRepository.GetAllWithExamStudentId(dto.Id);
            double grade = 0;

            foreach (var item in questions)
            {
                grade += item.Grade;
            }

            examStudent.SetGrade(grade, examStudent.ExamId , gradedQuestionRepository);

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

        public ExamStudentQuestion GetQuestion(ExamStudentQuestionGetDTO dto)
        {
            return examStudentQuestionRepository.GetWithExamStudentAndGradedQuestionId(dto.ExamStudentId , dto.GradedQuestionId);
        }

        public ExamStudentQuestion UpdateQuestion(ExamStudentQuestionUpdateDTO dto)
        {
            var examStudentQuestion = examStudentQuestionRepository.GetWithId(dto.Id);
            var examStudent = repository.GetWithId(examStudentQuestion.ExamStudentId);

            if(examStudent.EndTime<DateTime.Now)
            {
                return examStudentQuestion;
            }

            examStudentQuestion.Answer = dto.Answer;

            examStudentQuestionRepository.Update(examStudentQuestion);
            examStudentQuestionRepository.Save();

            return examStudentQuestion;
        }

        public List<ExamStudentQuestion> GetAllQuestionsByExamAndStudentId(ExamStudentQuestionsGetByExamAndStudentIdDTO dto)
        {
            var examStudent = repository.GetByExamAndStudentId(dto.ExamId, dto.StudentId);

            return examStudentQuestionRepository.GetAllWithExamStudentId(examStudent.Id);
        }
        
    }
}
