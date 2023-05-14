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
    public class MultipleChoiceAnswerRepository : BaseRepository<MultipleChoiceAnswer, ApiUser>, IMultipleChoiceAnswerRepository
    {
        public MultipleChoiceAnswerRepository(QuizSystemContext context) : base(context)
        {

        }

        public bool TitleExist(string title, Guid questionId)
        {
            return context.Set<MultipleChoiceAnswer>().Any(x => x.QuestionId == questionId && x.Title == title);
        }

        public bool RightAnswerExist(Guid questionId)
        {
            return context.Set<MultipleChoiceAnswer>().Where(x => x.QuestionId == questionId).Any(x => x.RightAnswer == true);
        }

        public List<MultipleChoiceAnswer> GetByQuestionId(Guid questionId)
        {
            return context.Set<MultipleChoiceAnswer>().Where(x => x.QuestionId == questionId).ToList() ;
        }
    }
}
