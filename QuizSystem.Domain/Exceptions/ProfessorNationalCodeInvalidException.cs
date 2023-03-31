﻿using Framework.Domain;
using System.Runtime.Serialization;

namespace QuizSystem.Domain.Exceptions
{
    public class ProfessorNationalCodeInvalidException : DomainException
    {
        public override string Message => ExceptionMessages.ProfessorNationalCodeInvalidExceptionMessage;
    }
}