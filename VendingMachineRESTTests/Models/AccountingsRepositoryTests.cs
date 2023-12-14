using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineREST.Models.Tests
{
    [TestClass()]
    public class AccountingsRepositoryTests
    {
        private static AccountingsDbContext? _context;
        private static AccountingsRepository? _accountingsRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var optionBuilder = new DbContextOptionsBuilder<AccountingsDbContext>();
            optionBuilder.UseSqlServer("Data Source = mssql4.unoeuro.com; Initial Catalog =  ozanhs_dk_db_vending_machine; Persist Security Info = True; User ID = ozanhs_dk; Password = GcB6m5g4awRnbE29tyzp; TrustServerCertificate = True");
            _context = new AccountingsDbContext(optionBuilder.Options);
            _accountingsRepository = new AccountingsRepository(_context);
        }

        [TestMethod()]
        public void AddTest()
        {
            AccountingsRepository accountingsRepository = new AccountingsRepository(_context);
            Accounting accounting = new Accounting() { UserId = 33, Amount = 10, Type = "M&M's" };
            accountingsRepository.Add(accounting);
            Assert.IsTrue(accounting.Id > 0);
        }

        [TestMethod()]
        public void GetAllTest()
        {

        }
    }
}