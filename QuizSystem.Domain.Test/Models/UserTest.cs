using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Test.Models
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void SetFirstName_Retrieve()
        {
            var user = InitialUser(DateTime.Now.AddYears(-22));
            var firstName = "mehran";
            Assert.AreEqual(firstName, user.FirstName);
        }

        [TestMethod]
        public void SetLastName_Retrieve()
        {
            var user = InitialUser(DateTime.Now.AddYears(-22));
            var lastName = "abdi";
            Assert.AreEqual(lastName, user.LastName);
        }

        [TestMethod]
        public void SetPassword_Retrieve()
        {
            var user = InitialUser(DateTime.Now.AddYears(-22));
            var password = "mehran1234";
            Assert.AreEqual(password, user.Password);
        }

        [TestMethod]
        public void SetBirthDate_Retrieve()
        {
            var user = InitialUser(new DateTime(2000,1,1));
            var birthDate = new DateTime(2000,1,1);
            Assert.AreEqual(birthDate, user.BirthDate);
        }

        [TestMethod]
        public void SetFirstName_FirstNameIsNullOrEmpty_ThrowException()
        {
            Assert.ThrowsException<UserFirstNameRequiredException>(() => InitialUser(new DateTime(2000, 1, 1), firstName: ""));
        }

        [TestMethod]
        public void SetLastName_LastNameIsNullOrEmpty_ThrowException()
        {
            Assert.ThrowsException<UserLastNameRequiredException>(() => InitialUser(new DateTime(2000, 1, 1), lastName: ""));
        }

        [TestMethod]
        [DataRow("m")]
        [DataRow("mehranabdi")]
        [DataRow("123456789")]
        public void SetPassword_PasswordIsNotSufficient_ThrowException(string password)
        {
            Assert.ThrowsException<UserPasswordInvalidException>(() => InitialUser(new DateTime(2000, 1, 1), password: password));
        }

        [TestMethod]
        public void SetBirthDate_BirthDateIsTooOldOrTooYoung_ThrowException()
        {
            Assert.ThrowsException<UserBirthDateInvalidValueException>(() => InitialUser(DateTime.Now.AddYears(-14)));
        }

        public User InitialUser(DateTime birthdate ,
            string firstName = "mehran",
            string lastName = "abdi",
            string password = "mehran1234"
            )
        {
            User user = new User(firstName,lastName,password,birthdate);
            return user;
        }
    }
}
