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
    public class DescriptiveQuestionRepository : BaseRepository<DescriptiveQuestion, ApiUser>, IDescriptiveQuestionRepository
    {
        public DescriptiveQuestionRepository(QuizSystemContext context) : base(context)
        {
        }

        public bool TitleExists(string title , Guid courseId , Guid professorId)
        {
            return context.Set<DescriptiveQuestion>().Any(x => x.Title == title && x.ProfessorId == professorId && x.CourseId == courseId);
        }

        public List<DescriptiveQuestion> GetWithCourseAndProfessorId(Guid courseId , Guid professorId)
        {
            return context.Set<DescriptiveQuestion>().Where(x => x.CourseId == courseId && x.ProfessorId == professorId).ToList();
        }
    }
}
