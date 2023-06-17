using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Exam:BaseEntity
    {
        public Exam()
        {

        }
        public Exam(ICourseRepository courseRepository , IExamRepository examRepository , string title , Guid courseId , string description , int time)
        {
            SetCourseId(courseId, courseRepository);
            SetTitle(title, examRepository);
            SetDescription(description);
            SetTime(time);
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Time { get; private set; }
        public Guid CourseId { get; private set; }

        public void SetTitle(string title , IExamRepository examRepository)
        {
            if (examRepository.IsExamTitleExist(title, CourseId))
                throw new ExamTitleExistException();
            Title = title;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void SetCourseId(Guid courseId , ICourseRepository courseRepository)
        {
            if (!courseRepository.IsExist(courseId))
                throw new CourseNotExistException();
            CourseId = courseId;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetTime(int time)
        {
            if (time < 1)
                throw new ExamTimeShortException();
            Time = time;
        }
    }
}
