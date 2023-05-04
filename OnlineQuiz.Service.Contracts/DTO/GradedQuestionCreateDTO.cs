using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class GradedQuestionCreateDTO
    {
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
        public double Grade { get; set; }
    }
}
