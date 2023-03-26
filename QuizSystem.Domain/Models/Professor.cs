using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Professor : BaseEntity
    {
        public Professor()
        {

        }

        public Professor(string firstName,
            string lastName,
            string nationalCode,
            string password,
            DateTime birthDate
            , IProfessorRepository repository
            )
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetNationalCode(nationalCode, repository);
            SetBirthDate(birthDate);
        }


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Accepted { get; set; } = false;

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ProfessorFirstNameRequiredException();
            FirstName = firstName;
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ProfessorLastNameRequiredException();
            LastName = lastName;
        }

        private void SetNationalCode(string nationalCode, IProfessorRepository repository)
        {
            if (repository.NationalCodeExists(nationalCode))
                throw new ProfessorNationalCodeExistsException();
            NationalCode = nationalCode;

        }

        private void SetBirthDate(DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year < 22 || DateTime.Now.Year - birthDate.Year > 100)
                throw new ProfessorBirthDateInvalidValueException();
            BirthDate = birthDate;
        }
    }
}