using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IExamStudentQuestionRepository: IBaseRepository<ExamStudentQuestion>
    {
        bool ExamStudentQuestionAlreadyExist(Guid examStudentId, Guid gradedQuestionId);
        ExamStudentQuestion GetWithExamStudentAndGradedQuestionId(Guid examStudentId, Guid gradedQuestionId);
    }
}