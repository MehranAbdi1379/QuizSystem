using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IDescriptiveQuestionRepository: IBaseRepository<DescriptiveQuestion>
    {
        public bool TitleExists(string title, Guid courseId, Guid professorId);
        public List<DescriptiveQuestion> GetWithCourseAndProfessorId(Guid courseId, Guid professorId);
    }
}