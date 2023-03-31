using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class CourseStudentAddNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.CourseStudentAddNullExceptionMessage;
    }
}