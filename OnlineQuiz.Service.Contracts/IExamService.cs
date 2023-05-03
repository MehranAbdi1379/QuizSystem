using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamService
    {
        Exam CreateExam(ExamCreateDTO dto);
        Exam UpdateExam(ExamUpdateDTO dto);
        public List<Exam> GetAllExamsByCourseId(IdDTO dto);
        public Exam GetById(IdDTO dto);
        public void DeleteExam(IdDTO dto);

    }
}