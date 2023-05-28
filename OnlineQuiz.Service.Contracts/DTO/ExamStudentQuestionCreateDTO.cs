using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class ExamStudentQuestionCreateDTO
    {
        public Guid ExamStudentId { get; set; }
        public Guid GradedQuestionId { get; set; }
        public string Answer { get; set; }
    }
}
