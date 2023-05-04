using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class QuestionNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.QuestionNotExistExceptionMessage;
    }
}