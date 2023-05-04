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
    public class GradedQuestionRepository : BaseRepository<GradedQuestion, ApiUser>, IGradedQuestionRepository
    {
        public GradedQuestionRepository(QuizSystemContext context) : base(context)
        {
        }

        public bool QuestionIsDuplicate(Guid questionId, Guid examId)
        {
            return context.Set<GradedQuestion>().Any(x => x.ExamId == examId && x.QuestionId == questionId);
        }

        public List<GradedQuestion> GetAllByExamId(Guid examId)
        {
            return context.Set<GradedQuestion>().Where(x => x.ExamId == examId).ToList();
        }
    }
}
