using Moq;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Test.Models
{
    [TestClass]
    public class CourseStudentTest
    {
        private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();
        private readonly Mock<IUserRepository<Student>> studentRepositoryMock = new Mock<IUserRepository<Student>>();

        public CourseStudentTest()
        {
            courseRepositoryMock.Setup(x=> x.IsExist(It.IsAny<Guid>())).Returns(true);
            studentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }

        [TestMethod]
        public void SetStudentId_Retrieve()
        {
            var courseStudent = InitialCourseStudent();
            var studentId = Guid.NewGuid();
            courseStudent.SetStudentId(studentId, studentRepositoryMock.Object);
            Assert.AreEqual(studentId, courseStudent.StudentId);
        }

        [TestMethod]
        public void SetCourseId_Retrieve()
        {
            var courseStudent = InitialCourseStudent();
            var courseId = Guid.NewGuid();
            courseStudent.SetCourseId(courseId, courseRepositoryMock.Object);
            Assert.AreEqual(courseId, courseStudent.CourseId);
        }


        public CourseStudent InitialCourseStudent()
        {
            var courseId = Guid.NewGuid();
            var studentId = Guid.NewGuid();
            return new CourseStudent(studentId, courseId, courseRepositoryMock.Object, studentRepositoryMock.Object);
        }
    }
}
