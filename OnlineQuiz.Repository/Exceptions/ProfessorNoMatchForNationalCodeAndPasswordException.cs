using Framework.Repository;
using QuizSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Repository.Exceptions
{
    public class ProfessorNoMatchForNationalCodeAndPasswordException : RepositoryException
    {
        public override string Message => ExceptionMessages.ProfessorNoMatchForNationalCodeAndPasswordExceptionMessage;
    }


}
