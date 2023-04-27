using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        bool CourseTitleExists(string title);
        public List<Guid> GetWithProfessorId(Guid professorID);
        public List<Course> GetAllCourses();
    }
}
