using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamStudentService
    {
        ExamStudent CountDownTimeLeft(IdDTO dto);
        ExamStudent Create(ExamStudentCreateDTO dto);
        void Delete(IdDTO dto);
        ExamStudent FinishExam(IdDTO dto);
        ExamStudent UpdateGrade(ExamStudentAddGradeDTO dto);
    }
}