using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class StudentAndProfessorSearchResultDTO
    {
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
    }
}
