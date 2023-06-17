using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IDescriptiveQuestionService
    {
        DescriptiveQuestion Create(QuestionCreateDTO dto);
        void Remove(IdDTO dto);
        List<DescriptiveQuestion> GetByCourseAndProfessorId(CourseAndProfessorIdDTO dto);
        DescriptiveQuestion Update(QuestionUpdateDTO dto);
        public DescriptiveQuestion GetById(IdDTO dto);
        List<DescriptiveQuestion> GetByExamId(IdDTO dto);
    }
}