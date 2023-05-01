using QuizSystem.Domain.Models;
using QuizSystem.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class CourseCreateDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guid> StudentIds { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
