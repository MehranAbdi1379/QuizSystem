using Moq;
using QuizSystem.Domain.Exceptions;
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
    public class ExamStudentTest
    {
        private readonly Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
        private readonly Mock<IStudentRepository> studentRepositoryMock = new Mock<IStudentRepository>();

        public ExamStudentTest()
        {
            examRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            studentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }

        [TestMethod]
        public void SetExamId_Retrieve()
        {
            var examId = Guid.NewGuid();
            var examStudent = InitialExamStudent(examId, Guid.NewGuid());
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
        public void SetTimeLeft_Retrieve()
        {
            var timeLeft = 5;
            var examStudent = InitialExamStudent(Guid.NewGuid() , Guid.NewGuid() , 0 , timeLeft);
            Assert.AreEqual(timeLeft, examStudent.TimeLeft);
        }

        [TestMethod]
        public void SetGrade_Retrieve()
        {
            var grade = 5;
            var examStudent = InitialExamStudent(Guid.NewGuid(), Guid.NewGuid(), grade);
            Assert.AreEqual(grade, examStudent.Grade);
        }


        public ExamStudent InitialExamStudent(Guid examId , Guid studentId , double grade = 0 , double timeLeft = 100)
        {
            return new ExamStudent(examId, studentId, grade, timeLeft, examRepositoryMock.Object, studentRepositoryMock.Object);
        }
    }
}
