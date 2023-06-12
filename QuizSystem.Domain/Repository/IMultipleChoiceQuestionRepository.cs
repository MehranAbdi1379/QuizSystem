using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IMultipleChoiceQuestionRepository: IBaseRepository<MultipleChoiceQuestion>
    {
        public bool TitleExist(string title, Guid professorId, Guid courseId);
        public List<MultipleChoiceQuestion> GetWithCourseAndProfessorId(Guid courseId, Guid professorId);
        List<MultipleChoiceQuestion> GetAllWithCourseId(Guid courseId);
    }
}