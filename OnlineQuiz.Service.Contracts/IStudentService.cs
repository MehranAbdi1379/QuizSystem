using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        Student AcceptStudent(StudentAcceptDTO dto);
        Student CreateStudent(CreateStudentDTO dto);
    }
}