using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class MultipleChoiceAnswerAlreadyHasRightAnswerException : DomainException
    {
        public override string Message => ExceptionMessages.MultipleChoiceAnswerAlreadyHasRightAnswerExceptionMessage;
    }
}