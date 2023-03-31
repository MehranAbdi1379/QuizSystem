using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class CourseUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Guid> StudentIds { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
