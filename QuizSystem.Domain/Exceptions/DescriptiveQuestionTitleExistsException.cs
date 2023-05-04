using Framework.Domain;
using QuizSystem.Domain.Exceptions;

namespace QuizSystem.Domain.Test.Models
{
    public class QuestionTitleExistsException: DomainException
    {
        public override string Message => ExceptionMessages.QuestionTitleExistsExceptionMessage;
    }
}