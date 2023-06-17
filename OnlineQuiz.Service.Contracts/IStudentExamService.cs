using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamStudentService
    {
        public ExamStudentQuestion UpdateGrade(ExamStudentQuestionUpdateGradeDTO dto);
        void Remove(IdDTO dto);
        ExamStudentQuestion UpdateQuestion(ExamStudentQuestionUpdateDTO dto);
        public ExamStudent Create(ExamStudentCreateDTO dto);
        public ExamStudent GetByStudentAndExamId(ExamStudentCreateDTO dto);
        public ExamStudentQuestion GetQuestion(ExamStudentQuestionGetDTO dto);
        public bool IsStudentExamExist(ExamStudentCreateDTO dto);
        public bool IsExamFinished(ExamStudentCreateDTO dto);
        public List<ExamStudent> GetAllByExamId(IdDTO dto);
        public List<ExamStudentQuestion> GetAllQuestionsByExamAndStudentId(ExamStudentQuestionsGetByExamAndStudentIdDTO dto);

    }
}