using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IMultipleChoiceAnswerRepository: IBaseRepository<MultipleChoiceAnswer>
    {
        public bool IsTitleExist(string title, Guid questionId);
        public bool IsRightAnswerExist(Guid questionId);
        public List<MultipleChoiceAnswer> GetByQuestionId(Guid questionId);

    }
}