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
    public class ExamStudentQuestion: BaseEntity
    {
        public ExamStudentQuestion()
        {

        }

        public ExamStudentQuestion(Guid examStudentId , Guid gradedQuestionId , string answer , IExamStudentRepository examStudentRepository, IGradedQuestionRepository gradedQuestionRepository)
        {
            SetExamStudentId(examStudentId , examStudentRepository);
            SetGradedQuestionId(gradedQuestionId, gradedQuestionRepository);
            Answer = answer;
        }

        public Guid ExamStudentId { get; private set; }
        public Guid GradedQuestionId { get; private set; }
        public string Answer { get; set; } 

        public void SetExamStudentId(Guid examStudentId , IExamStudentRepository examStudentRepository)
        {
            if (!examStudentRepository.IsExist(examStudentId))
                throw new ExamStudentNotExistException();
            ExamStudentId = examStudentId;
        }

        public void SetGradedQuestionId(Guid gradedQuestionId , IGradedQuestionRepository gradedQuestionRepository)
        {
            if (!gradedQuestionRepository.IsExist(gradedQuestionId))
                throw new GradedQuestionNotExistException();
            GradedQuestionId = gradedQuestionId;
        }
    }
}
