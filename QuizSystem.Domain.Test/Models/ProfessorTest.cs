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
        private readonly Mock<IProfessorRepository> professorRepositoryMock;
        public ProfessorTest()
        {
            professorRepositoryMock = new Mock<IProfessorRepository>();
        }

        [TestMethod]
        public void SetNationalCode_Retrieve()
        {
            var professor = InitialProfessor("5050062330");
            var nationalCode = "5050062330";
            Assert.AreEqual(nationalCode, professor.NationalCode);
        }

        [TestMethod]
        [DataRow("125050062330")]
        [DataRow("m505006233")]
        [DataRow("")]
        public void SetNationalCode_NationalCodeIsInvalid_ThrowException(string nationalCode)
        {
            Assert.ThrowsException<ProfessorNationalCodeInvalidException>(() => InitialProfessor(nationalCode));
        }

        [TestMethod]
        public void SetNationalCode_NationalCodeExists_ThrowException()
        {
            professorRepositoryMock.Setup(c => c.NationalCodeExists(It.IsAny<string>())).Returns(true);
            Assert.ThrowsException<ProfessorNationalCodeExistsException>(() => InitialProfessor("5050062330"));
        }

        [TestMethod]
        public void SetAccepted_Retrieve()
        {
            var professor = InitialProfessor("5050062330");
            var accepted = false;
            Assert.AreEqual(accepted, professor.Accepted);
        }

        [TestMethod]
        public void SetAccepted_SetAcceptedMethod()
        {
            var professor = InitialProfessor("5050062330");
            professor.SetAccepted(true);
            Assert.AreEqual(true, professor.Accepted);
        }

        public Professor InitialProfessor(string nationalCode)
        {
            return new Professor("mehran", "abdi", nationalCode, "mehran1234", DateTime.Now.AddYears(-20), professorRepositoryMock.Object);
        }
    }
}
