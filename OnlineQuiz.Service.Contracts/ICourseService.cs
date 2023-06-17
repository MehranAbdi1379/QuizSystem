using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface ICourseService
    {
        Guid AddStudentToCourse(CourseAndStudentIdDTO dto);
        Guid Create(CourseCreateDTO dto);
        Guid Update(CourseUpdateDTO dto);
        public List<Course> GetAll();
        public Course GetById(CourseIdStringDTO dto);
        public List<UserIdDTO> GetStudentsByCourseId(CourseIdStringDTO dto);
        public List<Course> GetByProfessorId(UserIdDTO dto);
        public void Remove(IdDTO dto);
        public List<Course> GetByStudentId(UserIdDTO dto);

    }
}