using System;
using CrawlerApp.Crawler;
using CrawlerApp.Interfaces;
using Moq;
using NUnit.Framework;

namespace CrawlerTests
{
    [TestFixture]
    internal class ConnectionCheckerTests
    {
        [SetUp]
        public void Init()
        {
            clientMock = new Mock<IWebClient>();
        }

        private Mock<IWebClient> clientMock;

        [Test]
        public void ReturnFalseWithoutInternet()
        {
            clientMock.Setup(m => m.DownloadString(It.IsAny<Uri>())).Returns((string) null);

            var checker = new ConnectionChecker(new Uri("http://test.com"), clientMock.Object);

            Assert.That(checker.IsConnected(), Is.False);
            clientMock.Verify(m => m.DownloadString(It.IsAny<Uri>()), Times.Once);
        }

        [Test]
        public void ReturnTrueIfHasInternetAccess()
        {
            clientMock.Setup(m => m.DownloadString(It.IsAny<Uri>())).Returns("Текст скачанной страницы");

            var checker = new ConnectionChecker(new Uri("http://test.com"), clientMock.Object);

            Assert.That(checker.IsConnected(), Is.True);
            clientMock.Verify(m => m.DownloadString(It.IsAny<Uri>()), Times.Once);
        }
    }
}