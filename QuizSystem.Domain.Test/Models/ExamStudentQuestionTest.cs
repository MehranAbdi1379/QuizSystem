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
    public class ExamStudentQuestionTest
    {
        protected readonly Mock<IExamStudentRepository> examStudentRepositoryMock = new Mock<IExamStudentRepository>();
        protected readonly Mock<IGradedQuestionRepository> gradedQuestionRepositoryMock = new Mock<IGradedQuestionRepository>();

        public ExamStudentQuestionTest()
        {
            examStudentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            gradedQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }

        [TestMethod]
        public void SetExamStudentId_Retrieve()
        {
            var examStudentId = Guid.NewGuid();
            var examStudentQuestion = initialExamStudentQuestion(examStudentId, Guid.NewGuid());
            Assert.AreEqual(examStudentId, examStudentQuestion.ExamStudentId);
        }

        [TestMethod]
        public void SetExamStudentId_ExamStudentNotExist_ThrowException()
        {
            examStudentRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<ExamStudentNotExistException>(() => initialExamStudentQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetGradedQuestionId_Retrieve()
        {
            var gradedQuestionId = Guid.NewGuid();
            var examStudentQuestion = initialExamStudentQuestion(Guid.NewGuid(), gradedQuestionId);
            Assert.AreEqual(gradedQuestionId, examStudentQuestion.GradedQuestionId);
        }

        [TestMethod]
        public void SetGradedQuestionId_GradedQuestionNotExist_ThrowException()
        {
            gradedQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<GradedQuestionNotExistException>(() => initialExamStudentQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetAnswer_Retrieve()
        {
            var answer = "answer";
            var examStudentQuestion = initialExamStudentQuestion(Guid.NewGuid(), Guid.NewGuid() , answer);
            Assert.AreEqual(answer, examStudentQuestion.Answer);
        }


        public ExamStudentQuestion initialExamStudentQuestion(Guid examStudentId , Guid gradedQuestionId , string answer="")
        {
            return new ExamStudentQuestion(examStudentId, gradedQuestionId, answer, examStudentRepositoryMock.Object, gradedQuestionRepositoryMock.Object);
        }
    }
}
