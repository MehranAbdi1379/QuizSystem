using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        public Student CreateStudent(StudentCreateDTO dto);
        public Student UpdateStudent(StudentUpdateDTO dto);
        public Student AcceptStudent(StudentAcceptDTO dto);
        public Student UnAcceptStudent(StudentAcceptDTO dto);
        public Professor ChangeStudentToProfessor(StudentIdDTO dto);
        public Student DeleteStudent(StudentIdDTO dto);
    }
}