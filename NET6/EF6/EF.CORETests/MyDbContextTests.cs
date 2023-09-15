using NUnit.Framework;
using EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace EF6.Tests
{
    [TestFixture()]
    public class MyDbContextTests
    {
        [Test()]
        public void TestDapperInsertBySQL()
        { 
            // Arrange
            var account = new Account()
            {
                AccountID = 1,
                Name = "ToulinTest",
                Age = 30
            };
            var mockContext = Substitute.For<MyDbContext>();
            // Act
            mockContext.TestDapperInsertBySQL(account);
            // Assert
            Assert.Fail();
        
        }
    }
}