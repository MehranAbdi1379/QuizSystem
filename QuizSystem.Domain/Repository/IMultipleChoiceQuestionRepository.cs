using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IMultipleChoiceQuestionRepository: IBaseRepository<MultipleChoiceQuestion>
    {
        public bool IsTitleExist(string title, Guid professorId, Guid courseId);
        public List<MultipleChoiceQuestion> GetByCourseAndProfessorId(Guid courseId, Guid professorId);
        List<MultipleChoiceQuestion> GetAllByCourseId(Guid courseId);
    }
}