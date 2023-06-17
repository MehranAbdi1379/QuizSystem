using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        public Student Create(Guid id);
        public void Remove(UserIdDTO dto);
        public Student Accept(UserIdDTO dto);
        public Student UnAccept(UserIdDTO dto);
        public void ChangeStudentToProfessor(UserIdDTO dto);
        public Task<StudentGetDTO> GetById(UserIdStringDTO dto);
        public Task<List<StudentGetDTO>> GetAll();
    }
}