using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudent> 
    {
        List<Guid> GetStudentIds(Guid courseId);
        List<Guid> GetCourseIds(Guid studentId);
    }
}
