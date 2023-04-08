using Framework.Service;
using System.Runtime.Serialization;

namespace QuizSystem.Service.Exceptions
{
    public class AdminSignInWrongNationalCodeOrPasswordException : ServiceException
    {
        public override string Message => ServiceExceptionMessages.AdminSignInWrongNationalCodeOrPasswordExceptionMessage;
    }
}