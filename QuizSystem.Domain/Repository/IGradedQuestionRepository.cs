using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IGradedQuestionRepository : IBaseRepository<GradedQuestion>
    {
        bool QuestionIsDuplicate(Guid questionId, Guid examId);
    }
}