using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string password,string nationalCode, DateTime birthdate , IUserRepository<Admin> repository) :
            base(firstName, lastName,password,birthdate)
        {
            SetNationalCode(nationalCode, repository);
        }

        public void SetNationalCode(string nationalCode, IUserRepository<Admin> repository)
        {
            if (repository.NationalCodeExists(nationalCode))
                throw new AdminNationalCodeExistsException();
            if (nationalCode.Length != 10 || Regex.IsMatch(nationalCode, "\\D"))
                throw new AdminNationalCodeInvalidException();
            NationalCode = nationalCode;
        }
    }
}
