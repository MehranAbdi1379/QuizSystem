using QuizSystem.Domain.Exceptions;
using System.Runtime.Serialization;

namespace QuizSystem.API.Controllers
{
    public class UserSearchTypeInvalidException : Exception
    {
        public override string Message => ExceptionMessages.UserSearchTypeInvalidExceptionMessage;
    }
}