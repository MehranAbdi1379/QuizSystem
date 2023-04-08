using Framework.api;
using QuizSystem.API.Exceptions;
using QuizSystem.Domain.Exceptions;
using System.Runtime.Serialization;

namespace QuizSystem.API.Controllers
{
    public class UserSearchTypeInvalidException : apiException
    {
        public override string Message => apiExceptionMessages.UserSearchTypeInvalidExceptionMessage;
    }
}