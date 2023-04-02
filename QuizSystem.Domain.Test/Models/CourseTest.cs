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
        studentRepositoryMock.Setup(c => c.IsExist(It.IsAny<Guid>())).Returns(false);
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
        var studentIds = new List<Guid>();
        var course = InitialCourse();
        course.SetStudents(studentIds,studentRepositoryMock.Object);

        Assert.AreEqual(studentIds , course.StudentIds);
    }

    [TestMethod]
    public void AddStudent_StudentDoesNotExist_ThrowException()
    {
        studentRepositoryMock.Setup(c => c.IsExist(It.IsAny<Guid>())).Returns(false);
        Guid studentId = Guid.NewGuid();
        Assert.ThrowsException<CourseStudentAddNotExistException>(() => InitialCourse().AddStudent(studentId,studentRepositoryMock.Object));
    }

    [TestMethod]
    public void AddStudent_StudentAlreadyExists_ThrowException()
    {
        List<Guid> studentIds = new List<Guid>();
        var studentId = Guid.NewGuid();
        studentIds.Add(studentId);
        studentRepositoryMock.Setup(c => c.IsExist(It.IsAny<Guid>())).Returns(false);
        var course = InitialCourse();
        course.SetStudents(studentIds,studentRepositoryMock.Object);
        studentRepositoryMock.Setup(c => c.IsExist(It.IsAny<Guid>())).Returns(true);
        Assert.ThrowsException<CourseAddStudentAlreadyExistsException>(() => course.AddStudent(studentId,studentRepositoryMock.Object));
    }

    private Course InitialCourse(
        List<Guid> studentIds = null,
        string title = "test",
        DateTime? startDate = null, 
        DateTime? endDate = null
        )
    {
        if (startDate == null)
            startDate = DateTime.Today.AddDays(1);
        
        if (endDate == null)
            endDate = DateTime.Today.AddDays(10);

        studentIds = new List<Guid>();

        Guid professorId = Guid.NewGuid();
        
        return new Course(title, startDate.Value, endDate.Value, courseRepositoryMock.Object , studentIds , professorId , professorRepositoryMock.Object , studentRepositoryMock.Object);
    }

}