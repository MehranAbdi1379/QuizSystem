using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class ExamRepository : BaseRepository<Exam, ApiUser>, IExamRepository
    {
        public ExamRepository(QuizSystemContext context) : base(context)
        {

        }

        public bool IsExamTitleExist(string title, Guid courseId)
        {
            return context.Set<Exam>().Where(s => s.CourseId == courseId).Any(s => s.Title == title);
        }

        public List<Exam> GetAllExams(Guid courseId)
        {
            return context.Set<Exam>().Where(x => x.CourseId == courseId).ToList();
        }
    }
}
