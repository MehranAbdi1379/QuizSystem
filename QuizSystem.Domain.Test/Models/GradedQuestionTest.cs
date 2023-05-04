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
    public class GradedQuestionTest
    {
        private readonly Mock<IGradedQuestionRepository> repository = new Mock<IGradedQuestionRepository>();
        private readonly Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
        private readonly Mock<IDescriptiveQuestionRepository> descriptiveQuestionRepositoryMock = new Mock<IDescriptiveQuestionRepository>();
        private readonly Mock<IMultipleChoiceQuestionRepository> multipleChoiceQuestionRepositoryMock = new Mock<IMultipleChoiceQuestionRepository>();
        public GradedQuestionTest()
        {
            examRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            descriptiveQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }
        [TestMethod]
        public void SetQuestionId_Retrieve()
        {
            descriptiveQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            var questionId = Guid.NewGuid();
            var question = initialQuestion(questionId, Guid.NewGuid());
            Assert.AreEqual(questionId, question.QuestionId);
        }

        [TestMethod]
        public void SetQuestionId_QuestionNotExist_ThrowException()
        {
            descriptiveQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<QuestionNotExistException>(() => initialQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }
        [TestMethod]
        public void SetExamId_Retrieve()
        {
            var examId = Guid.NewGuid();
            var question = initialQuestion(Guid.NewGuid(),examId);
            Assert.AreEqual(examId, question.ExamId);
        }

        [TestMethod]
        public void SetExamId_ExamNotExist_ThrowException()
        {
            examRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<ExamNotExistException>(() => initialQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        [TestMethod]
        public void SetGrade_Retrieve()
        {
            double grade = 1;
            var question = initialQuestion(Guid.NewGuid(), Guid.NewGuid() , grade);
            Assert.AreEqual(grade, question.Grade);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.1)]
        public void SetGrade_GradeIsLessOrEqualToZero_ThrowException(double grade)
        {
            Assert.ThrowsException<GradeQuestionGradeException>(() => initialQuestion(Guid.NewGuid(), Guid.NewGuid() , grade));
        }

        [TestMethod]
        public void ValidateDuplicate_GradedQuestionIsDuplicate_ThrowException()
        {
            repository.Setup(x => x.QuestionIsDuplicate(It.IsAny<Guid>() , It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<GradedQuestionDuplicateException>(() => initialQuestion(Guid.NewGuid(), Guid.NewGuid()));
        }

        public GradedQuestion initialQuestion(Guid questionId , Guid examId , double grade= 1)
        {
            return new GradedQuestion(questionId, examId, grade , repository.Object, multipleChoiceQuestionRepositoryMock.Object, examRepositoryMock.Object, descriptiveQuestionRepositoryMock.Object);
        }
    }
}
