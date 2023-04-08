using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Models;

namespace QuizSystem.Service
{
    public interface IStudentService
    {
        public Student CreateStudent(UserCreateDTO dto);
        public Student UpdateStudent(UserUpdateDTO dto);
        public Student AcceptStudent(UserIdDTO dto);
        public Student UnAcceptStudent(UserIdDTO dto);
        public Professor ChangeStudentToProfessor(UserIdDTO dto);
        public Student RemoveStudent(UserIdDTO dto);
        public List<Student> SearchStudent(StudentProfessorSearchDTO dto);
        public StudentAndProfessorSignedInDTO StudentSignIn(UserSignInDTO dto);
    }
}