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

        public ExamStudentService(IStudentRepository studentRepository, IExamRepository examRepository, IExamStudentRepository repository, IGradedQuestionRepository gradedQuestionRepository, IExamStudentQuestionRepository examStudentQuestionRepository)
        {
            this.studentRepository = studentRepository;
            this.examRepository = examRepository;
            this.repository = repository;
            this.gradedQuestionRepository = gradedQuestionRepository;
            this.examStudentQuestionRepository = examStudentQuestionRepository;
        }


        public ExamStudent CreateOrGet(ExamStudentCreateDTO dto)
        {
            if (repository.ExamStudentAlreadyExist(dto.ExamId, dto.StudentId))
                return repository.GetByExamAndStudentId(dto.ExamId, dto.StudentId);

            var examStudent = new ExamStudent(dto.ExamId, dto.StudentId, 0, examRepository.GetWithId(dto.ExamId).Time, examRepository, studentRepository);

            repository.Create(examStudent);
            repository.Save();

            //var gradedQuestions = gradedQuestionRepository.GetAllByExamId(dto.ExamId);
            //foreach (var item in gradedQuestions)
            //{
            //    examStudentQuestionRepository.Create(new ExamStudentQuestion(examStudent.Id , item.Id , "" , repository, gradedQuestionRepository));
            //}
            //examStudentQuestionRepository.Save();


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

        public ExamStudentQuestion CreateOrGetQuestion(ExamStudentQuestionCreateDTO dto)
        {
            if (examStudentQuestionRepository.ExamStudentQuestionAlreadyExist(dto.ExamStudentId, dto.GradedQuestionId))
                return examStudentQuestionRepository.GetWithExamStudentAndGradedQuestionId(dto.ExamStudentId, dto.GradedQuestionId);
            var examStudentQuestion = new ExamStudentQuestion(dto.ExamStudentId , dto.GradedQuestionId, dto.Answer, repository, gradedQuestionRepository);
            
            examStudentQuestionRepository.Create(examStudentQuestion);
            examStudentQuestionRepository.Save();

            return examStudentQuestion;
        }

        public ExamStudentQuestion UpdateQuestion(ExamStudentQuestionUpdateDTO dto)
        {
            var examStudentQuestion = examStudentQuestionRepository.GetWithId(dto.Id);
            examStudentQuestion.Answer = dto.Answer;

            examStudentQuestionRepository.Update(examStudentQuestion);
            examStudentQuestionRepository.Save();

            return examStudentQuestion;
        }
    }
}
