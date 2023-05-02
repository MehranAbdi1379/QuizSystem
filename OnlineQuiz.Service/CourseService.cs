using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
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

    public CourseService(ICourseRepository repository,
        IProfessorRepository professorRepository,
        IStudentRepository studentRepository,
        ICourseStudentRepository courseStudentRepository,
        IExamRepository examRepository)
    {
        this.repository = repository;
        this.professorRepository = professorRepository;
        this.studentRepository = studentRepository;
        this.courseStudentRepository = courseStudentRepository;
        this.examRepository = examRepository;
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

    public Exam CreateExam(ExamCreateDTO dto)
    {
        var exam = new Exam(repository, examRepository, dto.Title, dto.CourseId, dto.Description, dto.Time);
        examRepository.Create(exam);
        examRepository.Save();
        return exam;
    }

    public Exam UpdateExam(ExamUpdateDTO dto)
    {
        var exam = examRepository.GetWithId(dto.Id);
        exam.SetTime(dto.Time);
        exam.SetDescription(dto.Description);
        exam.SetTitle(dto.Title, examRepository);
        exam.SetCourseId(dto.CourseId, repository);
        examRepository.Update(exam);
        examRepository.Save();
        return exam;
    }

    public List<Exam> GetAllExamsByCourseId(CourseIdDTO dto)
    {
        return examRepository.GetAllExams(dto.Id);
    }

    public List<Course> GetCoursesByProfessorId(UserIdDTO dto)
    {
        var courseIds =  repository.GetWithProfessorId(dto.Id);
        var courses = new List<Course>();
        foreach (var item in courseIds)
        {
            courses.Add(repository.GetWithId(item));
        }
        return courses;
    }
}