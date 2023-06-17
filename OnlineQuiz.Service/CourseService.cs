using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

    public Guid Create(CourseCreateDTO dto)
    {
        var course = new Course(dto.Title,
            dto.StartDate,
            dto.EndDate,
            repository,
            dto.ProfessorId,
            professorRepository);

        repository.Create(course);
        repository.Save();

        Create_CreateCourseStudents(dto, course);

        return course.Id;
    }

    private void Create_CreateCourseStudents(CourseCreateDTO dto , Course course)
    {
        foreach (var studentId in dto.StudentIds)
        {
            var courseStudent = new CourseStudent(studentId, course.Id, repository, studentRepository);
            courseStudentRepository.Create(courseStudent);
        }

        courseStudentRepository.Save();
    }
    
    public void Remove(IdDTO dto)
    {
        var course = repository.GetWithId(dto.Id);
        var studentCourses = courseStudentRepository.GetByCourseId(dto.Id);
        foreach (var item in studentCourses)
        {
            courseStudentRepository.Delete(item);
        }
        courseStudentRepository.Save();

        repository.Delete(course);
        repository.Save();

        Remove_RemoveDescriptiveQuestions(dto);
        Remove_RemoveDescriptiveQuestions(dto);
        Remove_RemoveExams(dto);   
    }

    private void Remove_RemoveDescriptiveQuestions(IdDTO dto)
    {
        var descriptiveQuestions = descriptiveQuestionRepository.GetAllByCourseId(dto.Id);
        foreach (var item in descriptiveQuestions)
        {
            descriptiveQuestionService.Remove(new IdDTO { Id = item.Id });
        }
    }

    public void Remove_RemoveMultipleChoiceQuestions(IdDTO dto)
    {
        var multipleChoiceQuestions = multipleChoiceQuestionRepository.GetAllByCourseId(dto.Id);

        foreach (var item in multipleChoiceQuestions)
        {
            multipleChoiceQuestionService.Remove(new IdDTO { Id = item.Id });
        }
    }

    public void Remove_RemoveExams(IdDTO dto)
    {
        var exams = examRepository.GetAllExams(dto.Id);

        foreach (var item in exams)
        {
            examService.Remove(new IdDTO { Id = item.Id }); ;
        }
    }

    public Guid Update(CourseUpdateDTO dto)
    {
        var course = repository.GetWithId(dto.Id);
        course.UpdateTitle(dto.Title);
        course.UpdateDate(dto.StartDate, dto.EndDate);
        course.SetProfessor(dto.ProfessorId, professorRepository);

        Update_RemoveCourseStudents(course);
        Update_CreateCourseStudents(dto, course);

        repository.Update(course);
        repository.Save();

        return course.Id;
    }

    private void Update_RemoveCourseStudents(Course course)
    {
        foreach (var item in courseStudentRepository.GetByCourseId(course.Id))
        {
            courseStudentRepository.Delete(item);
        }
    }

    private void Update_CreateCourseStudents(CourseUpdateDTO dto , Course course)
    {
        foreach (var studentId in dto.StudentIds)
        {
            var courseStudent = new CourseStudent(studentId, course.Id, repository, studentRepository);
            courseStudentRepository.Create(courseStudent);
        }

        courseStudentRepository.Save();
    }

    public Guid AddStudentToCourse(CourseAndStudentIdDTO dto)
    {
        var courseStudent = new CourseStudent(dto.StudentId,dto.CourseId,repository,studentRepository);

        courseStudentRepository.Create(courseStudent);
        courseStudentRepository.Save();

        return dto.CourseId;
    }

    public List<Course> GetAll()
    {
        return repository.GetAllCourses();
    }

    public Course GetById(CourseIdStringDTO dto)
    {
        return repository.GetWithId(Guid.Parse(dto.Id));
    }

    public List<UserIdDTO> GetStudentsByCourseId(CourseIdStringDTO dto)
    {
        var courseStudents = courseStudentRepository.GetByCourseId(Guid.Parse(dto.Id));
        var studentIds = new List<UserIdDTO>();
        foreach (var item in courseStudents)
        {
            studentIds.Add(new UserIdDTO{Id = item.StudentId });
        }
        return studentIds;
    }

    public List<Course> GetByProfessorId(UserIdDTO dto)
    {
        return repository.GetByProfessorId(dto.Id);
    }
    public List<Course> GetByStudentId(UserIdDTO dto)
    {
        var courseStudents = courseStudentRepository.GetByStudentId(dto.Id);

        var courses = new List<Course>();
        foreach (var item in courseStudents)
        {
            courses.Add(repository.GetWithId(item.CourseId));
        }

        return courses;
    }
}