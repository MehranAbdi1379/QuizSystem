using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using QuizSystem.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {

        }

        public Course(string title, DateTime startTime, DateTime endTime , ICourseRepository repository)
        {
            SetTitle(title, repository);
            SetTime(startTime, endTime);
        }

        public string Title { get; private set; }
        public TimePeriod TimePeriod { get; private set; }
        public List<Student> Students { get; private set; }

        public void SetTitle(string title , ICourseRepository repository)
        {
            if (repository.CourseTitleExists(title))
                throw new CourseTitleExistsException();
            Title = title;
        }

        public void SetTime(DateTime startTime , DateTime endTime)
        {
            TimePeriod = new TimePeriod(startTime, endTime);
        }
        
    }
}