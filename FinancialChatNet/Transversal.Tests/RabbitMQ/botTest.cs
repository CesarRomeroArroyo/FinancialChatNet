using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transversal.RabbitMQ;
using Moq;
using System.Net;
using System.IO;
using System.Text;

namespace Transversal.Tests.RabbitMQ
{
    [TestClass]
    public class botTest
    {
        [TestMethod]
        public void verificateMessageSuccessfully()
        {
            bot botFinancial = new bot();
            bool returnBot = botFinancial.verificateMessage("/stock=");
            Assert.AreEqual(returnBot, true);
        }

        [TestMethod]
        public void verificateMessageUnsuccessfully()
        {
            bot botFinancial = new bot();
            bool returnBot = botFinancial.verificateMessage("test");
            Assert.AreEqual(returnBot, false);
        }

        [TestMethod]
        public void makeStookCall()
        {
            bot botFinancial = new bot();
            string responseReturn = "aapl quote is $174.18 per share";
            Mock<bot> botMock = new Mock<bot>();

            botMock.Setup(x => x.makeStookCall("aapl")).Returns(responseReturn);
            var stringReturn = botFinancial.makeStookCall("aapl");
            Assert.AreEqual(stringReturn, responseReturn);
        }



    }
}
