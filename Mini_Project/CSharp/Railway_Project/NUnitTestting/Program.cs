using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Railway_Project;


namespace NUnitTestting
{

    [TestFixture]
    public class AdminTests
    {
        [Test]
        public void AdminLoginCheckTrue()
        {
            // Arrange
            string adminName = "admin"; 
            string password = "admin123";

            // Act
            bool result = DataAccessAdmin.adminLoginCheck(adminName, password);

            // Assert
            ClassicAssert.IsTrue(result); 
        }

        [Test]
        public void AdminLoginCheckFalse()
        {
            string adminName = "invalidUser";
            string password = "wrongPassword";

            bool result = DataAccessAdmin.adminLoginCheck(adminName, password);

            ClassicAssert.IsFalse(result); 
        }
    }
}
