using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IProfessorService
    {
        public Professor CreateProfessor(StudentAndProfessorCreateDTO dto);
        public Professor UpdateProfessor(StudentAndProfessorUpdateDTO dto);
        public Professor RemoveProfessor(StudentAndProfessorIdDTO dto);
        public Professor AcceptProfessor(StudentAndProfessorIdDTO dto);
        public Professor UnAcceptProfessor(StudentAndProfessorIdDTO dto);
        public Student ChangeProfessorToStudent(StudentAndProfessorIdDTO dto);
        public List<Professor> SearchProfessor(StudentProfessorSearchDTO dto);

    }
}