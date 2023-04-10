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
        private readonly Mock<ICourseRepository> courseRepositoryMock;
        public ProfessorTest()
        {
            professorRepositoryMock = new Mock<IProfessorRepository>();
            courseRepositoryMock = new Mock<ICourseRepository>();
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

        public Professor InitialProfessor()
        {
            return new Professor();
        }
    }
}
