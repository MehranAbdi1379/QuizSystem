using Microsoft.VisualBasic;
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
    public class ProfessorTest
    {
        private readonly Mock<IUserRepository<Professor>> professorRepositoryMock;
        private readonly Mock<ICourseRepository> courseRepositoryMock;
        public ProfessorTest()
        {
            professorRepositoryMock = new Mock<IUserRepository<Professor>>();
            courseRepositoryMock = new Mock<ICourseRepository>();
        }

        [TestMethod]
        public void SetNationalCode_Retrieve()
        {
            var professor = InitialProfessor();
            var nationalCode = "5050062330";
            Assert.AreEqual(nationalCode, professor.NationalCode);
        }

        [TestMethod]
        [DataRow("125050062330")]
        [DataRow("m505006233")]
        [DataRow("")]
        public void SetNationalCode_NationalCodeIsInvalid_ThrowException(string nationalCode)
        {
            var professor = InitialProfessor();
            Assert.ThrowsException<ProfessorNationalCodeInvalidException>(() => professor.SetNationalCode(nationalCode, professorRepositoryMock.Object));
        }

        [TestMethod]
        public void SetNationalCode_NationalCodeExists_ThrowException()
        {
            var professor = InitialProfessor();
            professorRepositoryMock.Setup(c => c.NationalCodeExists(It.IsAny<string>())).Returns(true);
            Assert.ThrowsException<ProfessorNationalCodeExistsException>(() => professor.SetNationalCode("5050062330",professorRepositoryMock.Object));
        }

        [TestMethod]
        public void SetAccepted_Retrieve()
        {
            var professor = InitialProfessor();
            var accepted = false;
            Assert.AreEqual(accepted, professor.Accepted);
        }

        [TestMethod]
        public void SetAccepted_SetAcceptedMethod()
        {
            var professor = InitialProfessor();
            professor.SetAccepted(true);
            Assert.AreEqual(true, professor.Accepted);
        }

        public Professor InitialProfessor(string nationalCode = "5050062330")
        {
            return new Professor("mehran", "abdi", nationalCode, "mehran1234", DateTime.Now.AddYears(-20), professorRepositoryMock.Object);
        }
    }
}
