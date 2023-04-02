﻿using Microsoft.VisualBasic;
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
        public void SetNationalCode_Retrieve()
        {
            var student = InitialStudent();
            var nationalCode = "5050062330";
            Assert.AreEqual(nationalCode, student.NationalCode);
        }

        [TestMethod]
        [DataRow("125050062330")]
        [DataRow("m505006233")]
        [DataRow("")]
        public void SetNationalCode_NationalCodeIsInvalid_ThrowException(string nationalCode)
        {
            Assert.ThrowsException<StudentNationalCodeInvalidException>(() => InitialStudent(nationalCode));
        }

        [TestMethod]
        public void SetNationalCode_NationalCodeExists_ThrowException()
        {
            studentRepositoryMock.Setup(c => c.NationalCodeExists(It.IsAny<string>())).Returns(true);
            Assert.ThrowsException<StudentNationalCodeExistsException>(() => InitialStudent());
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
            return new Student("mehran", "abdi", nationalCode, "mehran1234", DateTime.Now.AddYears(-20),studentRepositoryMock.Object);
        }
    }
}
