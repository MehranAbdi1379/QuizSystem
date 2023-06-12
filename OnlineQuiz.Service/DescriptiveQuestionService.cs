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
    public class DescriptiveQuestionService : IDescriptiveQuestionService
    {
        private readonly IDescriptiveQuestionRepository descriptiveQuestionRepository;
        private readonly IProfessorRepository professorRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IExamRepository examRepository;
        private readonly IGradedQuestionService gradedQuestionService;
        private readonly IGradedQuestionRepository gradedQuestionRepository;
        public DescriptiveQuestionService(IDescriptiveQuestionRepository descriptiveQuestionRepository,
             IGradedQuestionService gradedQuestionService,ICourseRepository courseRepository, IProfessorRepository professorRepository, IExamRepository examRepository,
             IGradedQuestionRepository gradedQuestionRepository)
        {
            this.descriptiveQuestionRepository = descriptiveQuestionRepository;
            this.courseRepository = courseRepository;
            this.professorRepository = professorRepository;
            this.examRepository = examRepository;
            this.gradedQuestionService = gradedQuestionService;
            this.gradedQuestionRepository = gradedQuestionRepository;
        }

        public DescriptiveQuestion Create(QuestionCreateDTO dto)
        {
            var question = new DescriptiveQuestion(dto.Title, descriptiveQuestionRepository, dto.Description, professorRepository, courseRepository, dto.ProfessorId, dto.CourseId);
            descriptiveQuestionRepository.Create(question);
            descriptiveQuestionRepository.Save();
            return question;
        }

        public DescriptiveQuestion Update(QuestionUpdateDTO dto)
        {
            var question = descriptiveQuestionRepository.GetWithId(dto.Id);
            if (question.Title != dto.Title)
            {
                question.SetTitle(dto.Title, descriptiveQuestionRepository, dto.CourseId, dto.ProfessorId);
            }
            question.Description = dto.Description;

            descriptiveQuestionRepository.Update(question);
            descriptiveQuestionRepository.Save();

            return question;
        }

        public void Delete(IdDTO dto)
        {
            var gradedQuestions = gradedQuestionService.GetByQuestionId(dto);

            foreach (var gradedQuestion in gradedQuestions)
            {
                gradedQuestionService.Delete(new IdDTO { Id = gradedQuestion.Id });
            }
            var question = descriptiveQuestionRepository.GetWithId(dto.Id);
            descriptiveQuestionRepository.Delete(question);
            descriptiveQuestionRepository.Save();
        }

        public List<DescriptiveQuestion> GetWithCourseAndProfessorId(CourseAndProfessorIdDTO dto)
        {
            return descriptiveQuestionRepository.GetWithCourseAndProfessorId(dto.CourseId, dto.ProfessorId);
        }

        public DescriptiveQuestion GetWithId(IdDTO dto)
        {
            return descriptiveQuestionRepository.GetWithId(dto.Id);
        }

        public List<DescriptiveQuestion> GetWithExamId(IdDTO dto)
        {
            var questions = new List<DescriptiveQuestion>();
            var descriptiveGradedQuestions = gradedQuestionService.GetDescriptiveQuestionsOnly(dto);

            foreach (var item in descriptiveGradedQuestions)
            {
                questions.Add(descriptiveQuestionRepository.GetWithId(item.QuestionId));
            }

            return questions;
        }
    }
}
