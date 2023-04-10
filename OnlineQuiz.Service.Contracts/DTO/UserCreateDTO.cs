using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
    }
}
