using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class ExamStudentQuestionRepository : BaseRepository<ExamStudentQuestion, ApiUser>, IExamStudentQuestionRepository
    {
        public ExamStudentQuestionRepository(QuizSystemContext context) : base(context)
        {
        }

        public bool ExamStudentQuestionAlreadyExist(Guid examStudentId, Guid gradedQuestionId)
        {
            return context.Set<ExamStudentQuestion>().Any(x => x.ExamStudentId == examStudentId && x.GradedQuestionId == gradedQuestionId);
        }

        public ExamStudentQuestion GetWithExamStudentAndGradedQuestionId(Guid examStudentId, Guid gradedQuestionId)
        {
            return context.Set<ExamStudentQuestion>().Where(x => x.GradedQuestionId == gradedQuestionId && x.ExamStudentId == examStudentId).First();
        }

        public List<ExamStudentQuestion> GetAllWithExamStudentId(Guid examStudentId)
        {
            return context.Set<ExamStudentQuestion>().Where(x => x.ExamStudentId == examStudentId).ToList();
        }
    }
}
