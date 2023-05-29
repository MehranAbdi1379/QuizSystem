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
        private readonly ICourseRepository courseRepository;
        public GradedQuestionService(IGradedQuestionRepository gradedQuestionRepository , IDescriptiveQuestionRepository descriptiveQuestionRepository , 
            IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IExamRepository examRepository, ICourseRepository courseRepository)
        {
            this.examRepository = examRepository;
            this.gradedQuestionRepository = gradedQuestionRepository;
            this.descriptiveQuestionRepository = descriptiveQuestionRepository;
            this.multipleChoiceQuestionRepository  = multipleChoiceQuestionRepository;
            this.courseRepository = courseRepository;
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

        public List<GradedQuestion> GetAllByExamId(IdDTO dto)
        {
            return gradedQuestionRepository.GetAllByExamId(dto.Id);
        }

        public GradedQuestion Update(GradedQuestionUpdateDTO dto)
        {
            var question = gradedQuestionRepository.GetWithId(dto.Id);
            question.SetGrade(dto.Grade);

            gradedQuestionRepository.Update(question);
            gradedQuestionRepository.Save();

            return question;
        }

        public List<GradedQuestion> GetByQuestionId(IdDTO dto)
        {
            return gradedQuestionRepository.GetByQuestionId(dto.Id);
        }

        public List<GradedQuestion> GetDescriptiveQuestionsOnly(IdDTO dto)
        {
            var courseId = examRepository.GetWithId(dto.Id).CourseId;
            var professorId = courseRepository.GetWithId(courseId).ProfessorId;
            var descriptiveQuestions = descriptiveQuestionRepository.GetWithCourseAndProfessorId(courseId, professorId);
            var gradedQuestions = gradedQuestionRepository.GetAllByExamId(dto.Id);
            var result = new List<GradedQuestion>();
            foreach (var gradedQuestion in gradedQuestions)
            {
                foreach (var descriptiveQuestion in descriptiveQuestions)
                {
                    if (gradedQuestion.QuestionId==descriptiveQuestion.Id)
                        result.Add(gradedQuestion);
                }
            }

            return result;
        }

        public List<GradedQuestion> GetMultipleChoiceQuestionsOnly(IdDTO dto)
        {
            var courseId = examRepository.GetWithId(dto.Id).CourseId;
            var professorId = courseRepository.GetWithId(courseId).ProfessorId;
            var multipleChoiceQuestions = multipleChoiceQuestionRepository.GetWithCourseAndProfessorId(courseId, professorId);
            var gradedQuestions = gradedQuestionRepository.GetAllByExamId(dto.Id);
            var result = new List<GradedQuestion>();
            foreach (var gradedQuestion in gradedQuestions)
            {
                foreach (var multipleChoiceQuestion in multipleChoiceQuestions)
                {
                    if (gradedQuestion.QuestionId == multipleChoiceQuestion.Id)
                        result.Add(gradedQuestion);
                }
            }
            return result;
        }
    }
}
