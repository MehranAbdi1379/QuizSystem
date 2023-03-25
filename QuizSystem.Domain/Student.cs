using QuizSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain
{
    public class Student
    {
        public Student()
        {

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
    }
}
