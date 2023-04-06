using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class AdminNationalCodeExistsException : Exception
    {
        public override string Message => ExceptionMessages.AdminNationalCodeExistsExceptionMessage;
    }
}