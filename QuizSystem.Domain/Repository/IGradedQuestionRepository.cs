using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IGradedQuestionRepository : IBaseRepository<GradedQuestion>
    {
        bool IsQuestionDuplicate(Guid questionId, Guid examId);
        public List<GradedQuestion> GetAllByExamId(Guid examId);
        public List<GradedQuestion> GetByQuestionId(Guid questionId);
    }
}