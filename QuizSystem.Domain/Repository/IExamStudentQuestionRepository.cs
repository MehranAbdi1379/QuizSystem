using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IExamStudentQuestionRepository: IBaseRepository<ExamStudentQuestion>
    {
        bool IsExamStudentQuestionAlreadyExist(Guid examStudentId, Guid gradedQuestionId);
        ExamStudentQuestion GetByExamStudentAndGradedQuestionId(Guid examStudentId, Guid gradedQuestionId);
        List<ExamStudentQuestion> GetAllByExamStudentId(Guid examStudentId);
        List<ExamStudentQuestion> GetAllByGradedQuestionId(Guid gradedQuestionId);
    }
}