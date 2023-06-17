using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IMultipleChoiceQuestionService
    {
        MultipleChoiceQuestion Create(QuestionCreateDTO dto);
        MultipleChoiceAnswer CreateAnswer(MultipleChoiceAnswerCreateDTO dto);
        void Remove(IdDTO dto);
        void RemoveAnswer(IdDTO dto);
        List<MultipleChoiceQuestion> GetByCourseAndProfessorId(CourseAndProfessorIdDTO dto);
        MultipleChoiceQuestion Update(QuestionUpdateDTO dto);
        public List<MultipleChoiceAnswer> GetAnswersByQuestionId(IdDTO dto);
        public MultipleChoiceAnswer UpdateAnswer(MultipleChoiceAnswerUpdateDTO dto);
        public MultipleChoiceQuestion GetById(IdDTO dto);
        public List<MultipleChoiceQuestion> GetByExamId(IdDTO dto);
    }
}