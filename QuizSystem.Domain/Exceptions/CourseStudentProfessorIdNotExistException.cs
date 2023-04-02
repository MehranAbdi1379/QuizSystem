using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class CourseProfessorProfessorIdNotExistException : DomainException
    {
        public override string Message => ExceptionMessages.CourseProfessorProfessorIdNotExistExceptionMessage;
    }
}