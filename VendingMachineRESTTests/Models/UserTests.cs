using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineREST.Models.Tests
{
    [TestClass()]
    public class UserTests
    {

        [TestMethod]
        public void ValidateFirstNameTest()
        {
            User user = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            user.ValidateFirstName();
            Assert.AreEqual("John", user.FirstName);

            User nullUser = new User() { Id = 1, FirstName = null, LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentNullException>(() => nullUser.ValidateFirstName());

            User shortUser = new User() { Id = 1, FirstName = "J", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => shortUser.ValidateFirstName());
        }

        [TestMethod]
        public void ValidateLastNameTest()
        {
            User user = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            user.ValidateLastName();
            Assert.AreEqual("Doe", user.LastName);

            User nullUser = new User() { Id = 1, FirstName = "John", LastName = null, Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentNullException>(() => nullUser.ValidateLastName());

            User shortUser = new User() { Id = 1, FirstName = "John", LastName = "D", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => shortUser.ValidateLastName());
        }

        [TestMethod]
        public void ValidateEmailTest()
        {
            User user = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            user.ValidateEmail();
            Assert.AreEqual("johndoe@gmail.com", user.Email);

            User nullEmail = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = null, MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentNullException>(() => nullEmail.ValidateEmail());

            User noAt = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoegmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => noAt.ValidateEmail());

            User noDot = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmailcom", MobileNumber = "1234567890", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => noDot.ValidateEmail());
        }

        [TestMethod]
        public void ValidatePasswordTest()
        {
            User user = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudl" };
            user.ValidatePassword();
            Assert.AreEqual("udlrmudl", user.Password);

            User nullPassword = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = null };
            Assert.ThrowsException<ArgumentNullException>(() => nullPassword.ValidatePassword());

            User shortPassword = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmud" };
            Assert.ThrowsException<ArgumentException>(() => shortPassword.ValidatePassword());

            User longPassword = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890", Password = "udlrmudll" };
            Assert.ThrowsException<ArgumentException>(() => longPassword.ValidatePassword());
        }


        [TestMethod]
        public void ValidateMobilePhoneTest()
        {
            User user = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "12345678", Password = "udlrmudl" };
            user.ValidateMobileNumber();
            Assert.AreEqual("12345678", user.MobileNumber);

            User user2 = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567890123", Password = "udlrmudl" };
            user2.ValidateMobileNumber();
            Assert.AreEqual("1234567890123", user2.MobileNumber);

            User nullMobilePhone = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = null, Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentNullException>(() => nullMobilePhone.ValidateMobileNumber());

            User shortMobilePhone = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "1234567", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => shortMobilePhone.ValidateMobileNumber());

            User longMobilePhone = new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", MobileNumber = "12345678901234", Password = "udlrmudl" };
            Assert.ThrowsException<ArgumentException>(() => longMobilePhone.ValidateMobileNumber());

        }
    }
}