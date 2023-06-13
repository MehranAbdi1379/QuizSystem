using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
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

        public ExamStudent(Guid examId , Guid studentId ,IExamRepository examRepository , IStudentRepository studentRepository , IExamStudentRepository examStudentRepository, IGradedQuestionRepository gradedQuestionRepository)
        {
            ValidateUniqueExamStudent(examStudentRepository, examId, studentId);
            SetExamId(examId, examRepository);
            SetStudentId(studentId, studentRepository);
            SetTime( examId, examRepository);
        }
        public Guid ExamId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime StartTime{ get; private set; }
        public DateTime EndTime { get; private set; }

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

        public void ValidateUniqueExamStudent(IExamStudentRepository examStudentRepository , Guid examId , Guid studentId)
        {
            if (examStudentRepository.ExamStudentAlreadyExist(examId, studentId))
                throw new ExamStudentAlreadyExistException();
        }

        public void SetTime(Guid examId, IExamRepository examRepository)
        {
            var exam = examRepository.GetWithId(examId);

            StartTime = DateTime.Now;
            EndTime = StartTime.AddMinutes(exam.Time);
        }
    }
}
