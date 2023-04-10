using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IProfessorService
    {
        public Professor CreateProfessor(Guid id);
public Professor RemoveProfessor(UserIdDTO dto);
public Professor AcceptProfessor(UserIdDTO dto);
public Professor UnAcceptProfessor(UserIdDTO dto);
public void ChangeProfessorToStudent(UserIdDTO dto);


    }
}