using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Service.Contracts.DTO
{
    public class CreateStudentDTO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
