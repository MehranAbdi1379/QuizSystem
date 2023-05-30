using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class ExamStudentQuestionsGetByExamAndStudentIdDTO
    {
        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
    }
}
