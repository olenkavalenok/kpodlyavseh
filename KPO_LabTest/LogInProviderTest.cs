using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class LogInProviderTest
    {
        [TestMethod]
        public void LoginProvider()
        {
            //arrange
            string Login_Provider = "ad";
            string Password_Provider = "12";
            //act
            KPO_Lab.LogInProvider lip = new KPO_Lab.LogInProvider();
            bool res = true;
            //assert
            Assert.AreEqual(res, lip.Login_Password(Login_Provider, Password_Provider));
        }
    }
}