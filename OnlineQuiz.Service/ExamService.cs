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
        private readonly IGradedQuestionRepository gradedQuestionRepository;
        private readonly IExamStudentService examStudentService;
        private readonly IExamStudentRepository examStudentRepository;
        public ExamService(ICourseRepository courseRepository, IExamRepository repository, IGradedQuestionRepository gradedQuestionRepository,IExamStudentService examStudentService, IExamStudentRepository examStudentRepository)
        {
            this.courseRepository = courseRepository;
            this.repository = repository;
            this.gradedQuestionRepository = gradedQuestionRepository;
            this.examStudentService = examStudentService;
            this.examStudentRepository = examStudentRepository;
        }

        public Exam Create(ExamCreateDTO dto)
        {
            var exam = new Exam(courseRepository, repository, dto.Title, dto.CourseId, dto.Description, dto.Time);
            repository.Create(exam);
            repository.Save();
            return exam;
        }

        public Exam Update(ExamUpdateDTO dto)
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

        public List<Exam> GetAllByCourseId(IdDTO dto)
        {
            return repository.GetAllExams(dto.Id);
        }

        public Exam GetById(IdDTO dto)
        {
            return repository.GetWithId(dto.Id);
        }

        public void Remove(IdDTO dto)
        {
            var exam = repository.GetWithId(dto.Id);
            repository.Delete(exam);
            repository.Save();

            var gradedQuestions = gradedQuestionRepository.GetAllByExamId(dto.Id);
            foreach (var item in gradedQuestions)
            {
                gradedQuestionRepository.Delete(item);
            }
            gradedQuestionRepository.Save();

            var examStudents = examStudentRepository.GetAllByExamId(dto.Id);

            foreach (var item in examStudents)
            {
                examStudentService.Remove(new IdDTO { Id = item.Id }) ;
            }
        }

    }
}
