using Moq;
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
    public class MultipleChoiceQuestionTest
    {
        private readonly Mock<IMultipleChoiceQuestionRepository> multipleChoiceQuestionRepositoryMock = new Mock<IMultipleChoiceQuestionRepository>();
        private readonly Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();
        private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();

        public MultipleChoiceQuestionTest()
        {
            professorRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            courseRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        }
        [TestMethod]
        public void SetTitle_Retrieve()
        {
            var title = "";
            var question = InitialQuestion(title);
            Assert.AreEqual(title, question.Title);
        }

        [TestMethod]
        public void SetTitle_TitleAlreadyExists_ThrowException()
        {
            multipleChoiceQuestionRepositoryMock.Setup(x => x.IsTitleExist(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<QuestionTitleExistsException>(() => InitialQuestion());
        }

        public MultipleChoiceQuestion InitialQuestion(string title = "")
        {
            string description = "";
            var courseId = Guid.NewGuid();
            var professorId = Guid.NewGuid();
            return new MultipleChoiceQuestion(description,multipleChoiceQuestionRepositoryMock.Object , title, professorId,courseId,courseRepositoryMock.Object,professorRepositoryMock.Object);
        }
    }
}
