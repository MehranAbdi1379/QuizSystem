using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IGradedQuestionService
    {
        GradedQuestion Create(GradedQuestionCreateDTO dto);
        void Remove(IdDTO dto);
        public List<GradedQuestion> GetAllByExamId(IdDTO dto);
        public GradedQuestion Update(GradedQuestionUpdateDTO dto);
        public List<GradedQuestion> GetByQuestionId(IdDTO dto);
        public List<GradedQuestion> GetDescriptiveQuestionsOnly(IdDTO dto);
        public List<GradedQuestion> GetMultipleChoiceQuestionsOnly(IdDTO dto);

    }
}