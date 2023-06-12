using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service;

public class CourseService : ICourseService
{
    protected readonly ICourseRepository repository;
    protected readonly IProfessorRepository professorRepository;
    protected readonly IStudentRepository studentRepository;
    protected readonly ICourseStudentRepository courseStudentRepository;
    protected readonly IExamRepository examRepository;
    protected readonly IDescriptiveQuestionRepository descriptiveQuestionRepository;
    protected readonly IMultipleChoiceQuestionService multipleChoiceQuestionService;
    protected readonly IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository;
    protected readonly IDescriptiveQuestionService descriptiveQuestionService;
    protected readonly IExamService examService;

    public CourseService(ICourseRepository repository,
        IProfessorRepository professorRepository,
        IStudentRepository studentRepository,
        ICourseStudentRepository courseStudentRepository,
        IExamRepository examRepository,
        IDescriptiveQuestionRepository descriptiveQuestionRepository,
        IMultipleChoiceQuestionService multipleChoiceQuestionService
        ,IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository,
        IDescriptiveQuestionService descriptiveQuestionService,
        IExamService examService)
    {
        this.repository = repository;
        this.professorRepository = professorRepository;
        this.studentRepository = studentRepository;
        this.courseStudentRepository = courseStudentRepository;
        this.examRepository = examRepository;
        this.descriptiveQuestionRepository = descriptiveQuestionRepository;
        this.multipleChoiceQuestionService = multipleChoiceQuestionService;
        this.multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        this.descriptiveQuestionService = descriptiveQuestionService;
        this.examService = examService;
    }

    public Guid CreateCourse(CourseCreateDTO dto)
    {
        var course = new Course(dto.Title,
            dto.StartDate,
            dto.EndDate,
            repository,
            dto.ProfessorId,
            professorRepository);

        repository.Create(course);
        repository.Save();

        foreach (var studentId in dto.StudentIds)
        {
            CourseStudent courseStudent = new CourseStudent(studentId, course.Id, repository, studentRepository);
            courseStudentRepository.Create(courseStudent);
        }

        courseStudentRepository.Save();

        return course.Id;
    }
    
    public void RemoveCourse(IdDTO dto)
    {
        var course = repository.GetWithId(dto.Id);
        var studentCourses = courseStudentRepository.GetWithCourseId(dto.Id);
        foreach (var item in studentCourses)
        {
            courseStudentRepository.Delete(item);
        }
        courseStudentRepository.Save();

        repository.Delete(course);
        repository.Save();

        var descriptiveQuestions = descriptiveQuestionRepository.GetAllWithCourseId(dto.Id);
        foreach (var item in descriptiveQuestions)
        {
            descriptiveQuestionService.Delete(new IdDTO { Id = item.Id });
        }

        var multipleChoiceQuestions = multipleChoiceQuestionRepository.GetAllWithCourseId(dto.Id);

        foreach (var item in multipleChoiceQuestions)
        {
            multipleChoiceQuestionService.Delete(new IdDTO { Id = item.Id });
        }

        var exams = examRepository.GetAllExams(dto.Id);

        foreach (var item in exams)
        {
            examService.DeleteExam(new IdDTO { Id = item.Id});;
        }
    }

    public Guid UpdateCourse(CourseUpdateDTO dto)
    {
        Course course = repository.GetWithId(dto.Id);
        course.UpdateTitle(dto.Title);
        course.UpdateDate(dto.StartDate, dto.EndDate);
        course.SetProfessor(dto.ProfessorId, professorRepository);

        foreach (var item in courseStudentRepository.GetWithCourseId(course.Id))
        {
            courseStudentRepository.Delete(item);
        }

        foreach (var studentId in dto.StudentIds)
        {
            CourseStudent courseStudent = new CourseStudent(studentId, course.Id, repository, studentRepository);
            courseStudentRepository.Create(courseStudent);
        }

        courseStudentRepository.Save();
        repository.Update(course);
        repository.Save();

        return course.Id;
    }

    public Guid AddStudentToCourse(CourseAndStudentIdDTO dto)
    {
        CourseStudent courseStudent = new CourseStudent(dto.StudentId,dto.CourseId,repository,studentRepository);

        courseStudentRepository.Create(courseStudent);
        courseStudentRepository.Save();

        return dto.CourseId;
    }

    public List<Course> GetAllCourses()
    {
        return repository.GetAllCourses();
    }

    public Course GetCourseById(CourseIdStringDTO dto)
    {
        return repository.GetWithId(Guid.Parse(dto.Id));
    }

    public List<UserIdDTO> GetStudentsByCourseId(CourseIdStringDTO dto)
    {
        var courseStudents = courseStudentRepository.GetWithCourseId(Guid.Parse(dto.Id));
        var studentIds = new List<UserIdDTO>();
        foreach (var item in courseStudents)
        {
            studentIds.Add(new UserIdDTO{Id = item.StudentId });
        }
        return studentIds;
    }

    public List<Course> GetCoursesByProfessorId(UserIdDTO dto)
    {
        return repository.GetByProfessorId(dto.Id);
    }
    public List<Course> GetCourseByStudentId(UserIdDTO dto)
    {
        var courseStudents = courseStudentRepository.GetWithStudentId(dto.Id);

        var courses = new List<Course>();
        foreach (var item in courseStudents)
        {
            courses.Add(repository.GetWithId(item.CourseId));
        }

        return courses;
    }
}