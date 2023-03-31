using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class StudentNationalCodeInvalidException : DomainException
    {
        public override string Message => ExceptionMessages.StudentNationalCodeInvalidException;
    }
}