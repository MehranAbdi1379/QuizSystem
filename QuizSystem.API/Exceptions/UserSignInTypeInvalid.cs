using Framework.api;

namespace QuizSystem.API.Exceptions
{
    public class UserSignInTypeInvalidException : apiException
    {
        public override string Message => apiExceptionMessages.UserSignInTypeInvalidException;
    }
}
