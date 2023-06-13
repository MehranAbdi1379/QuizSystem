using Moq;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Test.Models
{
    [TestClass]
    public class ExamStudentTest
    {
        private readonly Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
        private readonly Mock<IStudentRepository> studentRepositoryMock = new Mock<IStudentRepository>();
        private readonly Mock<IExamStudentRepository> examStudentRepositoryMock= new Mock<IExamStudentRepository>();
        private readonly Mock<IGradedQuestionRepository> gradedQuestionRepositoryMock= new Mock<IGradedQuestionRepository>();
        private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();

        public ExamStudentTest()
        {
            examRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            studentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            courseRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            var exam = new Exam(courseRepositoryMock.Object, examRepositoryMock.Object, "a", Guid.NewGuid(), "a", 5);
            examRepositoryMock.Setup(x => x.GetWithId(It.IsAny<Guid>())).Returns(exam);
        }

        [TestMethod]
        public void SetExamId_Retrieve()
        {
            var examId = Guid.NewGuid();
            var examStudent = InitialExamStudent(examId, Guid.NewGuid() );
            Assert.AreEqual(examId, examStudent.ExamId);
        }

        [TestMethod]
        public void SetExamId_ExamIdNotExist_ThrowException()
        {
            examRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<ExamNotExistException>(() => InitialExamStudent(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetStudentId_Retrieve()
        {
            var studentId = Guid.NewGuid();
            var examStudent = InitialExamStudent(Guid.NewGuid(), studentId);
            Assert.AreEqual(studentId, examStudent.StudentId);
        }

        [TestMethod]
        public void SetStudentId_StudentIdNotExist_ThrowException()
        {
            studentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<StudentIdNotExistException>(() => InitialExamStudent(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetTime_Retrieve()
        {
            
            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddMinutes(5);
            var examStudent = InitialExamStudent(Guid.NewGuid() , Guid.NewGuid());
            Assert.AreEqual(startTime.Hour , examStudent.StartTime.Hour);
            Assert.AreEqual(startTime.Minute, examStudent.StartTime.Minute);
            Assert.AreEqual(startTime.Second, examStudent.StartTime.Second);
            Assert.AreEqual(endTime.Hour , examStudent.EndTime.Hour);
            Assert.AreEqual(endTime.Minute, examStudent.EndTime.Minute);
            Assert.AreEqual(endTime.Second, examStudent.EndTime.Second);
        }


        public ExamStudent InitialExamStudent(Guid examId , Guid studentId )
        {
            return new ExamStudent(examId, studentId, examRepositoryMock.Object, studentRepositoryMock.Object ,examStudentRepositoryMock.Object, gradedQuestionRepositoryMock.Object );
        }
    }
}
