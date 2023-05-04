using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class AnswerTitleAlreadyExistsException : DomainException
    {
        public override string Message => ExceptionMessages.AnswerTitleAlreadyExistsExceptionMessage;
    }
}