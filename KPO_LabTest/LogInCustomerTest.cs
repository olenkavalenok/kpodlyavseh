using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class LogInCustomerTest
    {
        [TestMethod]
        public void LoginCustomer()
        {
            //arrange
            string Login_Customer = "admin";
            string Password_Customer = "12345";
            //act
            KPO_Lab.LogInCustomer mc = new KPO_Lab.LogInCustomer();
            bool res = true;
            //assert
            Assert.AreEqual(res, mc.Login_Password(Login_Customer, Password_Customer));
        }
    }
}
