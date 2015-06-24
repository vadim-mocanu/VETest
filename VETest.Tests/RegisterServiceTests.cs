using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VETest.Service;

namespace VETest.Tests
{
	[TestClass]
    public class RegisterServiceTests
    {
        [TestMethod]
		public void GeneratePassword_PositiveTest()
        {
			// arrange
			const string userId = "user1";
            const string expectedPassword = "RWPFiQh70kh1AHMAZQByADEA";
            var dateTime = new DateTime(2015, 6, 21, 9, 10, 10);
            RegisterService registerService = new RegisterService();
			
			// act
			var password = registerService.GeneratePassword(userId, dateTime);
			
			// assert
			Assert.AreEqual(expectedPassword, password);
		}

        [TestMethod]
		public void GetTimeFromPassword_PosiviteTest()
        {
			// arrange
			var expectedDateTime = new DateTime(2015, 6, 21, 9, 10, 10);
            const string password = "RWPFiQh70kh1AHMAZQByADEA";
			RegisterService registerService = new RegisterService();
			
			// act
			var dateTime = registerService.GetTimeFromPassword(password);
			
			// assert
			Assert.AreEqual(expectedDateTime, dateTime);
		}
    }
}
