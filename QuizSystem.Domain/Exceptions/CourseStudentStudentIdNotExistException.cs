using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class CourseStudentStudentIdNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.CourseStudentStudentIdNotExistExceptionMessage;
    }
}