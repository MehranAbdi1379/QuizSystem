using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IMultipleChoiceQuestionService
    {
        MultipleChoiceQuestion Create(QuestionCreateDTO dto);
        MultipleChoiceAnswer CreateAnswer(MultipleChoiceAnswerCreateDTO dto);
        void Delete(IdDTO dto);
        void DeleteAnswer(IdDTO dto);
        List<MultipleChoiceQuestion> GetWithCourseAndProfessorId(CourseAndProfessorIdDTO dto);
        MultipleChoiceQuestion Update(QuestionUpdateDTO dto);
        public List<MultipleChoiceAnswer> GetAnswersByQuestionId(IdDTO dto);
        public MultipleChoiceAnswer UpdateAnswer(MultipleChoiceAnswerUpdateDTO dto);
        public MultipleChoiceQuestion GetWithId(IdDTO dto);
    }
}