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
    public class CourseStudentRepository : BaseRepository<CourseStudent> , ICourseStudentRepository
    {
        public CourseStudentRepository(QuizSystemContext context) : base(context)
        {

        }

        public List<Guid> GetCourseIds(Guid studentId)
        {
            return context.Set<CourseStudent>().Where(x => x.StudentId == studentId).Select(x => x.CourseId).ToList();
        }

        public List<Guid> GetStudentIds(Guid courseId)
        {
            return context.Set<CourseStudent>().Where(x=>x.CourseId==courseId).Select(x => x.StudentId).ToList();
        }
    }
}