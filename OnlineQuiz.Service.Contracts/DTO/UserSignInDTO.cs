using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class UserSignInDTO
    {
        public string NationalCode { get; set; }
        public string Password { get; set; }
    }
}
