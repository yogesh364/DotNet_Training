using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Railway_Project
{
    [TestClass]
    public class Test
    {
        [TestMethod]

        [DataRow("rahul", "admin_rahul@123", true)]
        [DataRow("invalidUser", "password123", false)]
        [DataRow("user1", "wrongPassword", false)]
        [DataRow("", "", false)]
        public void AdminLoginCheckTests(string username, string password, bool expectedResult)
        {
            bool result = DataAccessAdmin.adminLoginCheck(username, password);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]

        [DataRow("Yogesh", "Yogesh@123", true)]
        [DataRow("Sajjad", "Sajjad@123", true)]
        [DataRow("user1", "wrongPassword", false)]
        [DataRow("", "", false)]
        public void UserLoginCheckTests(string username, string password, bool expectedResult)
        {
            bool result = DataAccess.UserLoginCheck(username, password);
            Assert.AreEqual(expectedResult, result);
        }

        //    [TestMethod]
        //public void AdminLoginCheckTrue()
        //{
        //    string adminName = "rahul";
        //    string password = "admin_rahul@123";

        //    bool result = DataAccessAdmin.adminLoginCheck(adminName, password);

        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void AdminLoginCheckFalse()
        //{
        //    string adminName = "invalidUser";
        //    string password = "wrongPassword";

        //    bool result = DataAccessAdmin.adminLoginCheck(adminName, password);

        //    Assert.IsFalse(result);
        //}
    }
}

