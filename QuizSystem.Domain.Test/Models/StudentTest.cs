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
    public class StudentTest
    {
        private readonly Mock<IStudentRepository> studentRepositoryMock;
        private readonly Mock<ICourseRepository> courseRepositoryMock;
        public StudentTest()
        {
            studentRepositoryMock = new Mock<IStudentRepository>();
            courseRepositoryMock = new Mock<ICourseRepository>();
        }

        [TestMethod]
        public void SetAccepted_Retrieve()
        {
            var student = InitialStudent();
            var accepted = false;
            Assert.AreEqual(accepted, student.Accepted);
        }

        [TestMethod]
        public void SetAccepted_SetAcceptedMethod()
        {
            var student = InitialStudent();
            student.SetAccepted(true);
            Assert.AreEqual(true, student.Accepted);
        }


        public Student InitialStudent(string nationalCode = "5050062330")
        {
            return new Student();
        }
    }
}
