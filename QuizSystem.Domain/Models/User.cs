using Framework.Core.Domain;
using Framework.Repository;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class User : BaseEntity 
    {

        public User()
        {

        }
        public User(string firstName,
            string lastName,
            string password,
            DateTime birthDate
            )
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetBirthDate(birthDate);
            SetPassword(password);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string NationalCode { get; protected set; }


        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new UserFirstNameRequiredException();
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new UserLastNameRequiredException();
            LastName = lastName;
        }

        public void SetPassword(string password)
        {

            if (password.Length > 6 && Regex.IsMatch(password, "[a-zA-Z]") && Regex.IsMatch(password, "[0-9]"))
                Password = password;
            else
                throw new UserPasswordInvalidException();
        }

        public void SetBirthDate(DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year < 15 || DateTime.Now.Year - birthDate.Year > 150)
                throw new UserBirthDateInvalidValueException();
            BirthDate = birthDate;
        }

    }
}
