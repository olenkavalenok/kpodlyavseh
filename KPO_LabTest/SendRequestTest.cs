using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class SendRequestTest
    {
        [TestMethod]
        public void sendRequest()
        {
            //arrange
            //act
            KPO_Lab.Customer cust = new KPO_Lab.Customer(1);
            //assert
            Assert.IsTrue(cust.madeRequest());
        }
    }
}
