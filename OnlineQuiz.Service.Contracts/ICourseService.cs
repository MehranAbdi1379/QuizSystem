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
        public Course GetCourseById(CourseIdStringDTO dto);
        public List<UserIdDTO> GetStudentsByCourseId(CourseIdStringDTO dto);
        public Exam CreateExam(ExamCreateDTO dto);
        public Exam UpdateExam(ExamUpdateDTO dto);
        public List<Exam> GetAllExamsByCourseId(CourseIdDTO dto);
        public List<Course> GetCoursesByProfessorId(UserIdDTO dto);

    }
}