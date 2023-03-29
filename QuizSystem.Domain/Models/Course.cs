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
            SetProfessor(professor);
            SetTitle(title, repository);
            SetTime(startTime, endTime);
        }

        public string Title { get; set; }
        public TimePeriod TimePeriod { get; set; }
        public Professor Professor { get; set; }
        public List<Student> Students { get; set; }

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
        public void SetProfessor(Professor professor)
        {
            Professor = professor;
        }
    }
}
