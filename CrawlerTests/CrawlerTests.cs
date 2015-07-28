using CrawlerApp.Crawler;
using CrawlerApp.DAL.Interfaces;
using CrawlerApp.Interfaces;
using Moq;
using NUnit.Framework;
using VkNet;

namespace CrawlerTests
{
    [TestFixture]
    public class CrawlerTests
    {
        [SetUp]
        public void Init()
        {
            connectionMock = new Mock<IConnectionChecker>();
            loginMock = new Mock<IAuthorizer>();
            converterMock = new Mock<IUrlConverter>();
            dataProviderMock = new Mock<IDatabaseProvider>();
        }

        private Mock<IConnectionChecker> connectionMock;
        private Mock<IUrlConverter> converterMock;
        private Mock<IAuthorizer> loginMock;
        private Mock<IDatabaseProvider> dataProviderMock;
        private const string TestUrl = "http://test.com";

        [Test]
        public void StopIfGroupNotFound()
        {
            connectionMock.Setup(m => m.IsConnected()).Returns(true);
            loginMock.Setup(m => m.Login()).Returns(true);
            converterMock.SetupAllProperties();
            dataProviderMock.SetupAllProperties();

            var crawler = new Crawler(null, connectionMock.Object, loginMock.Object, converterMock.Object,
                dataProviderMock.Object, null);
            crawler.ProcessGroup(TestUrl);

            connectionMock.Verify(m => m.IsConnected(), Times.Once);
            loginMock.Verify(m => m.Login(), Times.Once);
            converterMock.Verify(m => m.GetGroupIdByUrl(TestUrl), Times.Once);
            dataProviderMock.Verify(m => m.SaveChanges(), Times.Never);
        }

        [Test]
        public void StopIfLoginFailed()
        {
            connectionMock.Setup(m => m.IsConnected()).Returns(true);
            loginMock.SetupAllProperties();
            converterMock.SetupAllProperties();

            var crawler = new Crawler(new VkApi(), connectionMock.Object, loginMock.Object, converterMock.Object, null, null);
            crawler.ProcessGroup(TestUrl);

            connectionMock.Verify(m => m.IsConnected(), Times.Once);
            loginMock.Verify(m => m.Login(), Times.Once);
            converterMock.Verify(m => m.GetGroupIdByUrl(TestUrl), Times.Never);
        }

        [Test]
        public void StopIfNotInternet()
        {
            connectionMock.SetupAllProperties();
            loginMock.SetupAllProperties();

            var crawler = new Crawler(null, connectionMock.Object, loginMock.Object, null, null, null);
            crawler.ProcessGroup(TestUrl);

            connectionMock.Verify(m => m.IsConnected(), Times.Once);
            loginMock.Verify(m => m.Login(), Times.Never);
        }
    }
}