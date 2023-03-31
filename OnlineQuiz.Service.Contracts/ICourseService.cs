using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface ICourseService
    {
        Course AddStudentToCourse(CourseAndStudentIdDTO dto);
        Course CreateCourse(CourseCreateDTO dto);
        Course UpdateCourse(CourseUpdateDTO dto);
    }
}