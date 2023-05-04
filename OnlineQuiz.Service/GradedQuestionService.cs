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
    public class GradedQuestionService : IGradedQuestionService
    {
        private readonly IGradedQuestionRepository gradedQuestionRepository;
        private readonly IDescriptiveQuestionRepository descriptiveQuestionRepository;
        private readonly IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository;
        private readonly IExamRepository examRepository;
        public GradedQuestionService()
        {

        }

        public GradedQuestion Create(GradedQuestionCreateDTO dto)
        {
            var answer = new GradedQuestion(dto.QuestionId, dto.ExamId, dto.Grade, gradedQuestionRepository, multipleChoiceQuestionRepository, examRepository, descriptiveQuestionRepository);
            gradedQuestionRepository.Create(answer);
            gradedQuestionRepository.Save();
            return answer;
        }

        public void Delete(IdDTO dto)
        {
            var answer = gradedQuestionRepository.GetWithId(dto.Id);
            gradedQuestionRepository.Delete(answer);
            gradedQuestionRepository.Save();
        }
    }
}
