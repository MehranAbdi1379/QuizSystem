﻿using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Exceptions
{
    public class ExamNotExistException: DomainException
    {
        public override string Message => ExceptionMessages.ExamNotExistExceptionMessage;
    }
}
