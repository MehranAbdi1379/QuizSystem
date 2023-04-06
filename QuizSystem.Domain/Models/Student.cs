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
            IUserRepository<Student> repository,
            bool accepted = false) : base(firstName, lastName, password, birthDate)
        {
            SetAccepted(accepted);
            SetNationalCode(nationalCode, repository);
        }

        public bool Accepted { get; private set; } = false;
        

        public void SetAccepted(bool accepted)
        {
            Accepted = accepted;
        }
        public void SetNationalCode(string nationalCode, IUserRepository<Student> repository)
        {
            if (repository.NationalCodeExists(nationalCode))
                throw new StudentNationalCodeExistsException();
            if (nationalCode.Length != 10 || Regex.IsMatch(nationalCode, "\\D"))
                throw new StudentNationalCodeInvalidException();
            NationalCode = nationalCode;
        }
    }
}
