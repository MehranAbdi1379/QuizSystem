using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository repository;
        private readonly ICourseRepository courseRepository;
        public ExamService(ICourseRepository courseRepository, IExamRepository repository)
        {
            this.courseRepository = courseRepository;
            this.repository = repository;
        }

        public Exam CreateExam(ExamCreateDTO dto)
        {
            var exam = new Exam(courseRepository, repository, dto.Title, dto.CourseId, dto.Description, dto.Time);
            repository.Create(exam);
            repository.Save();
            return exam;
        }

        public Exam UpdateExam(ExamUpdateDTO dto)
        {
            var exam = repository.GetWithId(dto.Id);
            exam.SetTime(dto.Time);
            exam.SetDescription(dto.Description);
            exam.UpdateTitle(dto.Title);
            exam.SetCourseId(dto.CourseId, courseRepository);
            repository.Update(exam);
            repository.Save();
            return exam;
        }

        public List<Exam> GetAllExamsByCourseId(IdDTO dto)
        {
            return repository.GetAllExams(dto.Id);
        }

        public Exam GetById(IdDTO dto)
        {
            return repository.GetWithId(dto.Id);
        }

        public void DeleteExam(IdDTO dto)
        {
            var exam = repository.GetWithId(dto.Id);
            repository.Delete(exam);
            repository.Save();
        }

    }
}
