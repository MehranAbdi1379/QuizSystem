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

        public Course(string title, DateTime startTime, DateTime endTime , Professor professor , ICourseRepository repository)
        {
            StartTime = startTime;
            EndTime = endTime;
            Professor = professor;

            SetTitle(title, repository);
            SetTime(startTime, endTime);
        }

        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Professor Professor { get; set; }
        public List<Student> Students { get; set; }

        private void SetTitle(string title , ICourseRepository repository)
        {
            if (repository.CourseTitleExists(title))
                throw new CourseTitleExistsException();
            Title = title;
        }

        private void SetTime(DateTime startTime , DateTime endTime)
        {
            TimePeriod timePeriod = new TimePeriod(startTime, endTime);
            timePeriod.ValidateTimePeriod();
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
