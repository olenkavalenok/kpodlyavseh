using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void LoginCustomer()
        {
            //arrange
            String Login_Customer = "admin";
            String Password_Customer = "1234";
            //act
            KPO_Lab.LogInCustomer mc = new KPO_Lab.LogInCustomer();
            bool res = true;
            //assert
            Assert.AreEqual(res, mc.Login_Password(Login_Customer, Password_Customer));
        }
    }
}
