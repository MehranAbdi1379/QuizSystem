using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.SingleDTO;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        Student AcceptStudent(StudentDTO dto);
        Student CreateStudent(StudentDTO dto);
        void RemoveStudent(StudentDTO dto);
    }
}