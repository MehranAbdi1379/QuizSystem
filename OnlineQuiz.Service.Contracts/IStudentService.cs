using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        public Student CreateStudent(StudentAndProfessorCreateDTO dto);
        public Student UpdateStudent(StudentAndProfessorUpdateDTO dto);
        public Student AcceptStudent(StudentAndProfessorIdDTO dto);
        public Student UnAcceptStudent(StudentAndProfessorIdDTO dto);
        public Professor ChangeStudentToProfessor(StudentAndProfessorIdDTO dto);
        public Student RemoveStudent(StudentAndProfessorIdDTO dto);
        public List<Student> SearchStudent(StudentProfessorSearchDTO dto);
    }
}