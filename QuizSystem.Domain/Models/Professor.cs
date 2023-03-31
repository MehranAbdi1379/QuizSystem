using Framework.Core.Domain;
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
    public class Professor : User
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
            ,bool accepted = false
            ) : base(firstName,lastName,password,birthDate)
        {
            SetNationalCode(nationalCode, repository);
        }


        public string NationalCode { get; private set; }
        public bool Accepted { get; private set; } = false;

        public List<Course> Courses { get; set; }

        private void SetNationalCode(string nationalCode, IProfessorRepository repository)
        {
            if (repository.NationalCodeExists(nationalCode))
                throw new ProfessorNationalCodeExistsException();
            if (nationalCode.Length != 10 || Regex.IsMatch(nationalCode, "\\D"))
                throw new ProfessorNationalCodeInvalidException();
            NationalCode = nationalCode;
        }
        public void SetAccepted(bool accepted)
        {
            Accepted = accepted;
        }
    }
}