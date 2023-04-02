using Framework.Core.Domain;
using Framework.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Student : User
    {
        public Student()
        {

        }

        public Student(string firstName,
            string lastName,
            string nationalCode,
            string password,
            DateTime birthDate,
            IStudentRepository repository,
            bool accepted = false) : base(firstName, lastName, password, birthDate)
        {
            SetNationalCode(nationalCode, repository);
            SetAccepted(accepted);
        }

        public bool Accepted { get; private set; } = false;
        public string NationalCode { get; private set; }

        public void SetNationalCode(string nationalCode, IStudentRepository repository)
        {
            if (repository.NationalCodeExists(nationalCode))
                throw new StudentNationalCodeExistsException();
            if (nationalCode.Length != 10 || Regex.IsMatch(nationalCode, "\\D"))
                throw new StudentNationalCodeInvalidException();
            NationalCode = nationalCode;
        }

        public void SetAccepted(bool accepted)
        {
            Accepted = accepted;
        }
    }
}
