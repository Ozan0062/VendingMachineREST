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
    public class AccountingTests
    {
        [TestMethod]
        public void ValidateTest()
        {
            User user = new User() { FirstName = "Silas", LastName = "Hansen", Email = "silas@gmail.com", MobileNumber = "24681014" };
            Accounting accounting = new Accounting() { UserId = 1, Amount = 1, Type = "M&M's"};
            accounting.Validate();
        }

        [TestMethod]
        public void ValidateAmountTest()
        {
            Accounting accounting = new Accounting() { Id = 1, Amount = 1, Type = "M&M's"};
            accounting.ValidateAmount();
            Assert.AreEqual(1, accounting.Amount);

            Accounting nullAmount = new Accounting() { Id = 1, Amount = 0, Type = "M&M's" };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => nullAmount.ValidateAmount());
        }

        [TestMethod]
        public void ValidateTypeTest()
        {
            Accounting accounting = new Accounting() { Id = 1, Amount = 1, Type = "M&M's" };
            accounting.ValidateType();
            Assert.AreEqual("M&M's", accounting.Type);

            Accounting nullType = new Accounting() { Id = 1, Amount = 1, Type = null };
            Assert.ThrowsException<ArgumentNullException>(() => nullType.ValidateType());

            Accounting shortType = new Accounting() { Id = 1, Amount = 1, Type = "M" };
            Assert.ThrowsException<ArgumentException>(() => shortType.ValidateType());
        }

        [TestMethod]
        public void ValidateDateTest()
        {
            Accounting accounting = new Accounting() { Id = 1, Amount = 1, Type = "M&M's"};
            accounting.ValidateDate();
            Assert.AreEqual(DateTime.Today, accounting.Date); 
        }
    }
}