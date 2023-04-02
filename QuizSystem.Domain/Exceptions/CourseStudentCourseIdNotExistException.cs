using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class CourseStudentCourseIdNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.CourseStudentCourseIdNotExistExceptionMessage;
    }
}