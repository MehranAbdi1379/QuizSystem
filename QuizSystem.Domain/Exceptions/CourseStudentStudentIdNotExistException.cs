using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class StudentIdNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.StudentIdNotExistExceptionMessage;
    }
}