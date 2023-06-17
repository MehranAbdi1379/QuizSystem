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
        bool IsCourseTitleExist(string title);
        public List<Course> GetByProfessorId(Guid professorID);
        public List<Course> GetAllCourses();
    }
}
