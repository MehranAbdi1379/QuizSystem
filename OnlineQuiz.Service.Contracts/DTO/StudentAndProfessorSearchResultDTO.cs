using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class UserSearchResultDTO
    {
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
