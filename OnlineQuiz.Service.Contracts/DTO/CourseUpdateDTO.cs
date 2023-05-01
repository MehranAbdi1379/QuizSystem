using QuizSystem.Domain.Value_Object;
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
        public TimePeriod TimePeriod { get; set; }
        public List<Guid> StudentIds { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
