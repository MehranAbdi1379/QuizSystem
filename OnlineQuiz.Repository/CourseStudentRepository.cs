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
    public class CourseStudentRepository : BaseRepository<CourseStudent,ApiUser> , ICourseStudentRepository
    {
        public CourseStudentRepository(QuizSystemContext context) : base(context)
        {

        }

        public List<CourseStudent> GetByStudentId(Guid studentId)
        {
            return context.Set<CourseStudent>().Where(x => x.StudentId == studentId).ToList();
        }

        public List<CourseStudent> GetByCourseId(Guid courseId)
        {
            return context.Set<CourseStudent>().Where(x=>x.CourseId==courseId).ToList();
        }
    }
}