using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IProfessorService
    {
        public Professor Create(Guid id);
public Professor Remove(UserIdDTO dto);
public Professor Accept(UserIdDTO dto);
public Professor UnAccept(UserIdDTO dto);
public void ChangeProfessorToStudent(UserIdDTO dto);
        public  Task<ProfessorGetDTO> GetById(UserIdStringDTO dto);
        public  Task<List<ProfessorGetDTO>> GetAll();



    }
}