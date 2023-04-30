using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        public Student CreateStudent(Guid id);
        public void RemoveStudent(UserIdDTO dto);
        public Student AcceptStudent(UserIdDTO dto);
        public Student UnAcceptStudent(UserIdDTO dto);
        public void ChangeStudentToProfessor(UserIdDTO dto);
        public Task<StudentGetDTO> GetStudentById(UserIdStringDTO dto);
        public Task<List<StudentGetDTO>> GetAllStudents();
    }
}