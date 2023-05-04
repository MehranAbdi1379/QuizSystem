using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IMultipleChoiceAnswerRepository: IBaseRepository<MultipleChoiceAnswer>
    {
        public bool TitleExist(string title, Guid questionId);
        public bool RightAnswerExist(Guid questionId);

    }
}