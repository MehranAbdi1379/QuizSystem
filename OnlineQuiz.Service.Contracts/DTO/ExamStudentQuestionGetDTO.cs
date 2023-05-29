using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class ExamStudentQuestionGetDTO
    {
        public Guid GradedQuestionId { get; set; }
        public Guid ExamStudentId { get; set; }
    }
}
