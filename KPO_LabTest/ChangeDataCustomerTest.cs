using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class ChangeDataCustomerTest
    {
        [TestMethod]
        public void changeCustomer()
        {
            //arrange
            string new_name_Customer = "newname";
            string new_login_Customer = "login";
            string new_password_Customer = "password";
            string new_telephone_Customer = "tel";
            string new_email_Customer = "mail";
            string new_numcard_Customer = "4000 1245 0004 3455";
            //act
            KPO_Lab.ChangeDataCustomer cdc = new KPO_Lab.ChangeDataCustomer(2);
            Assert.IsTrue(cdc.changeDataCustomer(new_name_Customer, new_login_Customer, new_password_Customer, new_telephone_Customer, new_email_Customer, new_numcard_Customer));
        }
    }
}