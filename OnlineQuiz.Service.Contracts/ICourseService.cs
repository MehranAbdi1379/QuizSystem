using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface ICourseService
    {
        Guid AddStudentToCourse(CourseAndStudentIdDTO dto);
        Guid CreateCourse(CourseCreateDTO dto);
        Guid UpdateCourse(CourseUpdateDTO dto);
        public List<Course> GetAllCourses();
    }
}