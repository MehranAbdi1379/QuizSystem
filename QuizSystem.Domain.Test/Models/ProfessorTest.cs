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
            professorRepositoryMock= new Mock<IProfessorRepository>();
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
        public void SetNationalCode_NationalCodeExists_ThrowException(string nationalCode)
        {
            Assert.ThrowsException<StudentNationalCodeInvalidException>(() => InitialProfessor(nationalCode));
        }

        [TestMethod]
        public void SetAccepted_Retrieve()
        {
            var student = InitialProfessor("5050062330");
            var accepted = false;
            Assert.AreEqual(accepted, student.Accepted);
        }

        [TestMethod]
        public void SetAccepted_SetAcceptedMethod()
        {
            var student = InitialProfessor("5050062330");
            student.SetAccepted(true);
            Assert.AreEqual(true, student.Accepted);
        }

        public Professor InitialProfessor(string nationalCode)
        {
            return new Professor("mehran", "abdi", nationalCode, "mehran1234", DateTime.Now.AddYears(-20),professorRepositoryMock.Object);
        }
    }
}
