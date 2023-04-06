using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IProfessorService
    {
        public Professor CreateProfessor(UserCreateDTO dto);
        public Professor UpdateProfessor(UserUpdateDTO dto);
        public Professor RemoveProfessor(UserIdDTO dto);
        public Professor AcceptProfessor(UserIdDTO dto);
        public Professor UnAcceptProfessor(UserIdDTO dto);
        public Student ChangeProfessorToStudent(UserIdDTO dto);
        public List<Professor> SearchProfessor(StudentProfessorSearchDTO dto);

    }
}