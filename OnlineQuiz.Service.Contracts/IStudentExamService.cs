using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamStudentService
    {
        ExamStudent CountDownTimeLeft(IdDTO dto);
        ExamStudent CreateOrGet(ExamStudentCreateDTO dto);
        void Delete(IdDTO dto);
        ExamStudent FinishExam(IdDTO dto);
        ExamStudent UpdateGrade(ExamStudentAddGradeDTO dto);
        public ExamStudentQuestion CreateOrGetQuestion(ExamStudentQuestionCreateDTO dto);
        public ExamStudentQuestion UpdateQuestion(ExamStudentQuestionUpdateDTO dto);

    }
}