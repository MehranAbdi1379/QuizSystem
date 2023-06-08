using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class ExamStudentQuestionUpdateGradeDTO
    {
        public Guid Id { get; set; }
        public double Grade { get; set; }
    }
}
