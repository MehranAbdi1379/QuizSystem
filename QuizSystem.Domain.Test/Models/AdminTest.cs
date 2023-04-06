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
    public class AdminTest
    {
        private readonly Mock<IUserRepository<Admin>> repository = new Mock<IUserRepository<Admin>>(); 

        [TestMethod]
        public void SetNationalCode_Retrieve()
        {
            var nationalCode = "1234567891";
            var admin = initialAdmin(nationalCode:nationalCode);
            Assert.AreEqual(nationalCode, admin.NationalCode);
        }

        [TestMethod]
        public void SetNationalCode_NationalCodeAlreadyExists_ThrowException()
        {
            repository.Setup(c => c.NationalCodeExists(It.IsAny<string>())).Returns(true);
            Assert.ThrowsException<AdminNationalCodeExistsException>(() => initialAdmin());
        }

        [TestMethod]
        [DataRow("125050062330")]
        [DataRow("m505006233")]
        [DataRow("")]
        public void SetNationalCode_NationalCodeIsInvalid_ThrowException(string nationalCode)
        {
            Assert.ThrowsException<AdminNationalCodeInvalidException>(() => initialAdmin(nationalCode:nationalCode));
        }

        public Admin initialAdmin(string firstName = "Mehran",
            string lastName = "Abdi",
            string nationalCode = "5050062330",
            string password ="mehran1234"
            )
        {
            DateTime birthDate = new DateTime(2000,10,1);
            return new Admin(firstName, lastName, password, nationalCode, birthDate, repository.Object);
        }
    }
}
