using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class AdminNationalCodeInvalidException : Exception
    {
        public override string Message => ExceptionMessages.AdminNationalCodeInvalidExceptionMessage;
    }
}