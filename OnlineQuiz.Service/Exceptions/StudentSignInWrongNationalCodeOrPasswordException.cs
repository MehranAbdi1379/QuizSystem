using Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Exceptions
{
    public class StudentSignInWrongNationalCodeOrPasswordException : ServiceException
    {
        public override string Message => ServiceExceptionMessages.StudentSignInWrongNationalCodeOrPasswordExceptionMessage;
    }
}
