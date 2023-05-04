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
    public class QuestionTest
    {
        private readonly Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();
        private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();

        public QuestionTest()
        {
            professorRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            courseRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }

        [TestMethod]
        public void SetProfessorId_Retrieve()
        {
            var professorId = Guid.NewGuid();
            var question = InitialQuestion(professorId, Guid.NewGuid());
            Assert.AreEqual(professorId, question.ProfessorId);
        }

        [TestMethod]
        public void SetProfessorId_ProfessorNotExist_ThrowException()
        {
            professorRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<ProfessorIdNotExistException>(() => InitialQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetCourseId_Retrieve()
        {
            var courseId = Guid.NewGuid();
            var question = InitialQuestion(Guid.NewGuid(), courseId);
            Assert.AreEqual(courseId, question.CourseId);
        }

        [TestMethod]
        public void SetCourseId_CourseNotExist_ThrowException()
        {
            courseRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<CourseNotExistException>(() => InitialQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        public Question InitialQuestion( Guid professorId , Guid courseId , string title = "", string description = "" )
        {
            
                return new Question( description, professorId, courseId , professorRepositoryMock.Object, courseRepositoryMock.Object);
            
        }
    }

    
}
