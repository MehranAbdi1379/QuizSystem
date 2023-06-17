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
    public class DescriptiveQuestionTest
    {
        private readonly Mock<IDescriptiveQuestionRepository> descriptiveQuestionRepositoryMock = new Mock<IDescriptiveQuestionRepository>();
        private readonly Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();
        private readonly Mock<ICourseRepository> courseRepositoryMock = new Mock<ICourseRepository>();

        public DescriptiveQuestionTest()
        {
            professorRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            courseRepositoryMock.Setup(x=>x.IsExist(It.IsAny<Guid>())).Returns(true);
        }
        [TestMethod]
        public void SetTitle_Retrieve()
        {
            var title = "";
            var question = InitialQuestion(title);
            Assert.AreEqual(title, question.Title);
        }

        [TestMethod]
        public void SetTitle_QuestionTitleExists_ThrowException()
        {
            descriptiveQuestionRepositoryMock.Setup(x => x.IsTitleExist(It.IsAny<string>() , It.IsAny<Guid>(),It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<QuestionTitleExistsException>(() => InitialQuestion());
        }

        public DescriptiveQuestion InitialQuestion(string title = ""  )
        {
            string description = "";
            var courseId = Guid.NewGuid();
            var professorId = Guid.NewGuid();
            return new DescriptiveQuestion(title ,descriptiveQuestionRepositoryMock.Object ,description,professorRepositoryMock.Object,courseRepositoryMock.Object,professorId,courseId);
        }
    }
}
