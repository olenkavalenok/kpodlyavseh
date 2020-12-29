using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPO_Lab.Test
{
    [TestClass]
    public class SendMessageTest
    {
        [TestMethod]
        public void sendMess()
        {
            //arrange
            string adres = "iphonemskopt@gmail.com";
            string text = "Hello!";
            //act
            KPO_Lab.MessageForm mf = new KPO_Lab.MessageForm(1);
            Assert.IsTrue(mf.sendMessage(adres, text));
        }
    }
}