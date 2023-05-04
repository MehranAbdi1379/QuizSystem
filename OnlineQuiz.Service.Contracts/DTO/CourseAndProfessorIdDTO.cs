using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class CourseAndProfessorIdDTO
    {
        public Guid ProfessorId { get; set; }
        public Guid CourseId { get; set; }
    }
}
