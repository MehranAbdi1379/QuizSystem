using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class ExamStudent: BaseEntity
    {
        public ExamStudent()
        {

        }

        public ExamStudent(Guid examId , Guid studentId , double grade , double timeLeft,IExamRepository examRepository , IStudentRepository studentRepository)
        {
            SetExamId(examId, examRepository);
            SetStudentId(studentId, studentRepository);
            Grade = grade;
            TimeLeft = timeLeft;
        }
        public Guid ExamId { get; private set; }
        public Guid StudentId { get; private set; }
        public double Grade { get; set; }
        public double TimeLeft { get; set; }

        public void SetExamId(Guid examId , IExamRepository examRepository)
        {
            if (!examRepository.IsExist(examId))
                throw new ExamNotExistException();
            ExamId = examId;
        }

        public void SetStudentId(Guid studentId , IStudentRepository studentRepository)
        {
            if(!studentRepository.IsExist(studentId))
                throw new StudentIdNotExistException();
            StudentId = studentId;
        }
    }
}
