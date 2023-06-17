using Framework.Core.Domain;
using Microsoft.Extensions.Options;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class GradedQuestion : BaseEntity
    {
        public GradedQuestion()
        {

        }
        public GradedQuestion(Guid questionId , Guid examId , double grade , IGradedQuestionRepository repository , IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository
            , IExamRepository examRepository , IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            ValidateQuestionNotDuplicate(questionId,examId,repository);
            SetQuestionId(questionId,multipleChoiceQuestionRepository , descriptiveQuestionRepository);
            SetExamId(examId, examRepository);
            SetGrade(grade);
        }

        public Guid QuestionId{ get; private set; }
        public Guid ExamId { get; private set; }
        public double Grade { get; private set; }

        public void SetQuestionId(Guid questionId , IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository , IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            if (!multipleChoiceQuestionRepository.IsExist(questionId) && !descriptiveQuestionRepository.IsExist(questionId))
                throw new QuestionNotExistException();
            QuestionId = questionId;
        }

        public void SetExamId(Guid examId , IExamRepository examRepository)
        {
            if (!examRepository.IsExist(examId))
                throw new ExamNotExistException();
            ExamId = examId;
        }

        public void SetGrade(double grade)
        {
            if (grade <= 0)
                throw new GradeQuestionGradeException();
            Grade = grade;
        }

        public void ValidateQuestionNotDuplicate(Guid questionId , Guid examId,IGradedQuestionRepository repository)
        {
            if (repository.IsQuestionDuplicate(questionId, examId))
                throw new GradedQuestionDuplicateException();
        }
    }
}
