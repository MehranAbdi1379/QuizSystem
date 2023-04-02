using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class CourseStudent : BaseEntity
    {
        public CourseStudent()
        {

        }

        public CourseStudent(Guid studentId , Guid courseId, ICourseRepository courseRepository , IStudentRepository studentRepository)
        {
            SetStudentId(studentId, studentRepository);
            SetCourseId(courseId, courseRepository);
        }

        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public void SetStudentId(Guid studentId, IStudentRepository studentRepository)
        {
            if (!studentRepository.IsExist(studentId))
                throw new CourseStudentStudentIdNotExistException();
            StudentId = studentId;
        }

        public void SetCourseId(Guid courseId , ICourseRepository courseRepository)
        {
            if (!courseRepository.IsExist(courseId))
                throw new CourseStudentCourseIdNotExistException();
            CourseId = courseId;
        }
    }
}