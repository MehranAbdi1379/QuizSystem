using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamStudentService
    {
        ExamStudent UpdateGrade(IdDTO dto);
        void Delete(IdDTO dto);
        ExamStudentQuestion UpdateQuestion(ExamStudentQuestionUpdateDTO dto);
        public ExamStudent Create(ExamStudentCreateDTO dto);
        public ExamStudent GetByStudentAndExamId(ExamStudentCreateDTO dto);
        public ExamStudentQuestion GetQuestion(ExamStudentQuestionGetDTO dto);
        public bool StudentExamExist(ExamStudentCreateDTO dto);


    }
}