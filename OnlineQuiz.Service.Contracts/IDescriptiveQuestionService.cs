using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IDescriptiveQuestionService
    {
        DescriptiveQuestion Create(QuestionCreateDTO dto);
        void Delete(IdDTO dto);
        List<DescriptiveQuestion> GetWithCourseAndProfessorId(CourseAndProfessorIdDTO dto);
        DescriptiveQuestion Update(QuestionUpdateDTO dto);
        public DescriptiveQuestion GetWithId(IdDTO dto);
        List<DescriptiveQuestion> GetWithExamId(IdDTO dto);
    }
}