using Moq;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Test.Models
{
    [TestClass]
    public class MultipleChoiceAnswerTest
    {
        private readonly Mock<IMultipleChoiceAnswerRepository> multipleChoiceAnswerRepositoryMock  = new Mock<IMultipleChoiceAnswerRepository>();
        private readonly Mock<IMultipleChoiceQuestionRepository> multipleChoiceQuestionRepositoryMock = new Mock<IMultipleChoiceQuestionRepository>();
        public MultipleChoiceAnswerTest()
        {
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }
        [TestMethod]
        public void SetTitle()
        {
            var title = "";
            var answer = InitialAnswer(Guid.NewGuid(), title);
            Assert.AreEqual(title, answer.Title);
        }

        [TestMethod]
        public void SetTitle_TitleAlreadyExists_ThrowException()
        {
            multipleChoiceAnswerRepositoryMock.Setup(x=>x.IsTitleExist(It.IsAny<string>() , It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<AnswerTitleAlreadyExistsException>(() => InitialAnswer(Guid.NewGuid()));
        }

        [TestMethod]
        public void SetQuestionId_Retrieve()
        {
            var questionId = Guid.NewGuid();
            var answer = InitialAnswer(questionId);
            Assert.AreEqual(questionId , answer.QuestionId);
        }

        [TestMethod]
        public void SetQuestionId_QuestionNotExist_ThrowException()
        {
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<QuestionNotExistException>(() => InitialAnswer(Guid.NewGuid()));
        }

        [TestMethod]
        public void SetRightAnswer_Retrieve()
        {
            var rightAnswer = false;
            var answer = InitialAnswer(Guid.NewGuid(), rightAnswer: rightAnswer);
            Assert.AreEqual(rightAnswer, answer.RightAnswer);
        }

        [TestMethod]
        public void SetRightAnswer_RightAnswerAlreadyExist_ThrowException()
        {
            multipleChoiceAnswerRepositoryMock.Setup(x => x.IsRightAnswerExist(It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<MultipleChoiceAnswerAlreadyHasRightAnswerException>(() => InitialAnswer(Guid.NewGuid() , rightAnswer: true));
        }

        public MultipleChoiceAnswer InitialAnswer(Guid questionId, string title = "", bool rightAnswer= false)
        {
            return new MultipleChoiceAnswer(rightAnswer, multipleChoiceAnswerRepositoryMock.Object, title, questionId, multipleChoiceQuestionRepositoryMock.Object);
        }
    }
}
