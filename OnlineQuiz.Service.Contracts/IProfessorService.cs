using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service.Contracts.SingleDTO;

namespace QuizSystem.Service
{
    public interface IProfessorService
    {
        Professor AcceptStudent(ProfessorDTO dto);
        Professor CreateStudent(ProfessorDTO dto);
        void RemoveStudent(ProfessorDTO dto);
    }
}