using Framework.Repository;
using Microsoft.EntityFrameworkCore;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class CourseRepository : BaseRepository<Course> , ICourseRepository
    {
        public CourseRepository(DataBaseContext context) : base(context)
        {

        }

        public bool CourseTitleExists(string title)
        {
            return context.Set<Course>().Any(s => s.Title == title);
        }
    }
}