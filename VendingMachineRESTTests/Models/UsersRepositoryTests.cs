using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendingMachineREST.Models;

namespace VendingMachineREST.Models.Tests
{
    [TestClass()]
    public class UsersRepositoryTests
    {
        private static UsersDbContext? _context;
        private static UsersRepository? _usersRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var optionBuilder = new DbContextOptionsBuilder<UsersDbContext>();
            optionBuilder.UseSqlServer("Data Source = mssql4.unoeuro.com; Initial Catalog =  ozanhs_dk_db_vending_machine; Persist Security Info = True; User ID = ozanhs_dk; Password = GcB6m5g4awRnbE29tyzp; TrustServerCertificate = True");
            _context = new UsersDbContext(optionBuilder.Options);
            _usersRepository = new UsersRepository(_context);
        }

        //[TestMethod]
        //public void AddTest()
        //{
        //    UsersRepository usersRepository = new UsersRepository(_context);
        //    User user = new User() { FirstName = "Silas", LastName = "Hansen", Email = "silashansen2@gmail.com", MobilePhone = "24681015" };
        //    usersRepository.Add(user);
        //    Assert.IsTrue(user.Id > 0);
        //}

        [TestMethod]
        public void GetAllTest()
        {
            UsersRepository? usersRepository = new UsersRepository(_context);
            IEnumerable<User?> users = usersRepository.GetAll();
            Assert.AreEqual(5, users.Count());
        }
    }
}