using Moq;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Domain.Value_Object;

namespace QuizSystem.Domain.Test.Models;

[TestClass]
public class CourseTest
{
    private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();
    private readonly Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();
    private readonly Mock<IStudentRepository> studentRepositoryMock = new Mock<IStudentRepository>();

    public CourseTest()
    {
        courseRepositoryMock.Setup(c => c.CourseTitleExists(It.IsAny<string>())).Returns(false);
        professorRepositoryMock.Setup(c => c.GetWithId(It.IsAny<Guid>())).Returns(new Professor());
        studentRepositoryMock.Setup(c => c.GetWithId(It.IsAny<Guid>())).Returns(new Student());
    }

    [TestMethod]
    public void SetTitle_CourseTitleExist_ThrowException()
    {
        courseRepositoryMock.Setup(c => c.CourseTitleExists(It.IsAny<string>())).Returns(true);
        Assert.ThrowsException<CourseTitleExistsException>(() => InitialCourse());
    }

    [TestMethod]
    public void SetTitle_Retrieve()
    {
        var title = "test";
        var course = InitialCourse(title:title);
        Assert.AreEqual(title, course.Title);
    }

    [TestMethod]
    public void SetTime_Retrieve()
    {
        var time = new TimePeriod(DateTime.Now.AddDays(1), DateTime.Now.AddDays(10)); 
        var course = InitialCourse(startDate:time.StartDate , endDate:time.EndDate);
        Assert.AreEqual(time.StartDate, course.TimePeriod.StartDate);
        Assert.AreEqual(time.EndDate, course.TimePeriod.EndDate);
    }

    [TestMethod]
    public void SetProfessor_Retrieve()
    {
        var professor = new Professor();
        var professorId = professor.Id;
        var course = InitialCourse();
        course.SetProfessor(professorId,professorRepositoryMock.Object);

        Assert.AreEqual(professorId, course.ProfessorId);
    }

    [TestMethod]
    public void SetStudents_Retrieve()
    {
        var students = new List<Student>();
        var course = InitialCourse();
        course.SetStudents(students);

        Assert.AreEqual(students , course.Students);
    }

    [TestMethod]
    public void SetStudent_AddStudent()
    {
        var student = new Student("mehran","abdi","5050062330","mehran1234" , DateTime.Now.AddYears(-20) , studentRepositoryMock.Object);
        var course = InitialCourse();
        course.AddStudent(student,studentRepositoryMock.Object);

        Assert.AreEqual(student, course.Students.FirstOrDefault(student));
    }

    private Course InitialCourse(
        List<Student> students = null,
        string title = "test",
        DateTime? startDate = null, 
        DateTime? endDate = null
        )
    {
        if (startDate == null)
            startDate = DateTime.Today.AddDays(1);
        
        if (endDate == null)
            endDate = DateTime.Today.AddDays(10);

        students = new List<Student>();

        Guid professorId = Guid.NewGuid();
        
        return new Course(title, startDate.Value, endDate.Value, courseRepositoryMock.Object , students , professorId , professorRepositoryMock.Object);
    }

}