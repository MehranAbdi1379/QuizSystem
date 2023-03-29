using Framework.Repository;
using QuizSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.Exceptions
{
    public class StudentNoMatchForNationalCodeAndPasswordException : RepositoryException
    {
        public override string Message => ExceptionMessages.StudentNoMatchForNationalCodeAndPasswordExceptionMessage;
    }


}
