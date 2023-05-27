using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class MultipleChoiceAnswer: BaseEntity
    {
        public MultipleChoiceAnswer()
        {

        }
        public MultipleChoiceAnswer(bool rightAnswer,IMultipleChoiceAnswerRepository repository , string title, Guid questionId , IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            SetQuestionId(questionId, multipleChoiceQuestionRepository);
            SetTitle(title, repository, questionId);
            SetRightAnswer(rightAnswer, repository, questionId);
        }

        public string Title { get; private set; }
        public bool RightAnswer { get; private set; }
        public Guid QuestionId { get; private set; }

        public void SetRightAnswer(bool rightAnswer , IMultipleChoiceAnswerRepository repository , Guid questionId)
        {
            if(rightAnswer)
            {
                if (repository.RightAnswerExist(questionId))
                    throw new MultipleChoiceAnswerAlreadyHasRightAnswerException();
                RightAnswer = rightAnswer;
            }
            else
            {
                RightAnswer = rightAnswer;
            }
        }

        public void SetTitle(string title , IMultipleChoiceAnswerRepository repository , Guid questionId)
        {
            if (repository.TitleExist(title, questionId))
                throw new AnswerTitleAlreadyExistsException();
            Title = title;
        }

        public void SetQuestionId(Guid questionId , IMultipleChoiceQuestionRepository repository)
        {
            if (!repository.IsExist(questionId))
                throw new QuestionNotExistException();
            QuestionId = questionId;
        }
    }
}
