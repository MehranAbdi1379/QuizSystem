using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IExamService
    {
        Exam Create(ExamCreateDTO dto);
        Exam Update(ExamUpdateDTO dto);
        public List<Exam> GetAllByCourseId(IdDTO dto);
        public Exam GetById(IdDTO dto);
        public void Remove(IdDTO dto);

    }
}