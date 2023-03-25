using Framework.Domain;
using QuizSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain
{
    public class Student : BaseEntity
    {
        public Student()
        {

        }

        public Student(string firstName,
            string lastName,
            string nationalCode,
            string password,
            DateTime birthDate
            )
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetNationalCode(nationalCode);
            SetBirthDate(birthDate);
        }


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new StudentFirstNameRequiredException();
            FirstName = firstName;
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new StudentLastNameRequiredException();
            LastName = lastName;
        }

        private void SetNationalCode(string nationalCode)
        {

        }

        private void SetBirthDate(DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year < 15 || DateTime.Now.Year - birthDate.Year > 100)
                throw new StudentBirthDateInvalidValueException();
            BirthDate = birthDate;
        }
    }
}
