using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
    {
        private readonly IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository;
        private readonly IProfessorRepository professorRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IMultipleChoiceAnswerRepository multipleChoiceAnswerRepository;
        public MultipleChoiceQuestionService(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, ICourseRepository courseRepository, IProfessorRepository professorRepository, IMultipleChoiceAnswerRepository multipleChoiceAnswerRepository)
        {
            this.multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            this.courseRepository = courseRepository;
            this.professorRepository = professorRepository;
            this.multipleChoiceAnswerRepository = multipleChoiceAnswerRepository;
        }

        public MultipleChoiceQuestion Create(QuestionCreateDTO dto)
        {
            var question = new MultipleChoiceQuestion(dto.Description, multipleChoiceQuestionRepository, dto.Title, dto.ProfessorId, dto.CourseId, courseRepository, professorRepository);
            multipleChoiceQuestionRepository.Create(question);
            multipleChoiceQuestionRepository.Save();
            return question;
        }

        public MultipleChoiceQuestion Update(QuestionUpdateDTO dto)
        {
            var question = multipleChoiceQuestionRepository.GetWithId(dto.Id);
            if (question.Title != dto.Title)
            {
                question.SetTitle(dto.Title, multipleChoiceQuestionRepository, dto.CourseId, dto.ProfessorId);
            }
            question.Description = dto.Description;

            multipleChoiceQuestionRepository.Update(question);
            multipleChoiceQuestionRepository.Save();

            return question;
        }

        public void Delete(IdDTO dto)
        {
            var question = multipleChoiceQuestionRepository.GetWithId(dto.Id);
            var answers = multipleChoiceAnswerRepository.GetByQuestionId(question.Id);
            foreach (var item in answers)
            {
                multipleChoiceAnswerRepository.Delete(item);
            }
            multipleChoiceAnswerRepository.Save();
            multipleChoiceQuestionRepository.Delete(question);
            multipleChoiceQuestionRepository.Save();
        }

        public List<MultipleChoiceQuestion> GetWithCourseAndProfessorId(CourseAndProfessorIdDTO dto)
        {
            return multipleChoiceQuestionRepository.GetWithCourseAndProfessorId(dto.CourseId, dto.ProfessorId);
        }

        public MultipleChoiceAnswer CreateAnswer(MultipleChoiceAnswerCreateDTO dto)
        {
            var answer = new MultipleChoiceAnswer(dto.RightAnswer, multipleChoiceAnswerRepository, dto.Title, dto.QuestionId, multipleChoiceQuestionRepository);
            multipleChoiceAnswerRepository.Create(answer);
            multipleChoiceAnswerRepository.Save();
            return answer;
        }

        public void DeleteAnswer(IdDTO dto)
        {
            var answer = multipleChoiceAnswerRepository.GetWithId(dto.Id);
            multipleChoiceAnswerRepository.Delete(answer);
            multipleChoiceAnswerRepository.Save();
        }

        public List<MultipleChoiceAnswer> GetAnswersByQuestionId(IdDTO dto)
        {
            return multipleChoiceAnswerRepository.GetByQuestionId(dto.Id);
        }

        public MultipleChoiceAnswer UpdateAnswer(MultipleChoiceAnswerUpdateDTO dto)
        {
            var answer = multipleChoiceAnswerRepository.GetWithId(dto.Id);
            answer.SetTitle(dto.Title,multipleChoiceAnswerRepository,dto.QuestionId);
            answer.SetQuestionId(dto.QuestionId, multipleChoiceQuestionRepository);

            multipleChoiceAnswerRepository.Update(answer);
            multipleChoiceAnswerRepository.Save();

            return answer;
        }
    }
}
