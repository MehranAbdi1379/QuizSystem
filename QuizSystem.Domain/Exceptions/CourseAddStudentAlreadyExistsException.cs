using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class CourseAddStudentAlreadyExistsException : DomainException
    {
        public override string Message => ExceptionMessages.CourseAddStudentAlreadyExistsExceptionMessage;
    }
}