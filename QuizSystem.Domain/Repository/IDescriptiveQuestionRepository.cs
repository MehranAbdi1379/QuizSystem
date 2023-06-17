using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Repository
{
    public interface IDescriptiveQuestionRepository: IBaseRepository<DescriptiveQuestion>
    {
        public bool IsTitleExist(string title, Guid courseId, Guid professorId);
        public List<DescriptiveQuestion> GetByCourseAndProfessorId(Guid courseId, Guid professorId);
        List<DescriptiveQuestion> GetAllByCourseId(Guid courseId);
    }
}