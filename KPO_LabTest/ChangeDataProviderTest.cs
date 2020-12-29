using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class ChangeDataProviderTest
    {
        [TestMethod]
        public void changeCustomer()
        {
            //arrange
            string new_name_Provider = "name1";
            string new_login_Provider = "login1";
            string new_password_Provider = "password1";
            string new_telephone_Provider = "53027";
            string new_email_Provider = "email1";
            string new_numcard_Provider = "4000 1235 0000 0346";
            //act
            KPO_Lab.ChangeDataProvider cdp = new KPO_Lab.ChangeDataProvider(2);
            Assert.IsTrue(cdp.changeDataProvider(new_name_Provider, new_login_Provider, new_password_Provider, new_telephone_Provider, new_email_Provider, new_numcard_Provider));
        }
    }
}