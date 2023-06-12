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
    public class MultipleChoiceQuestionRepository : BaseRepository<MultipleChoiceQuestion, ApiUser>, IMultipleChoiceQuestionRepository
    {
        public MultipleChoiceQuestionRepository(QuizSystemContext context) : base(context)
        {

        }

        public bool TitleExist(string title , Guid professorId , Guid courseId)
        {
            return context.Set<MultipleChoiceQuestion>().Any(x => x.Title == title && x.ProfessorId == professorId && x.CourseId ==courseId);
        }

        public List<MultipleChoiceQuestion> GetWithCourseAndProfessorId(Guid courseId, Guid professorId)
        {
            return context.Set<MultipleChoiceQuestion>().Where(x => x.CourseId == courseId && x.ProfessorId == professorId).ToList();
        }

        public List<MultipleChoiceQuestion> GetAllWithCourseId(Guid courseId)
        {
            return context.Set<MultipleChoiceQuestion>().Where(x => x.CourseId == courseId).ToList();
        }
    }
}
