using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class ProfessorAddCourseNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.ProfessorAddCourseNotExistExceptionMessage;
    }
}