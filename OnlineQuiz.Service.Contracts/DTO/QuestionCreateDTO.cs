using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class QuestionCreateDTO
    {
        public string Title{ get; set; }
        public Guid CourseId { get; set; }
        public Guid ProfessorId { get; set; }
        public string Description { get; set; }
    }
}
