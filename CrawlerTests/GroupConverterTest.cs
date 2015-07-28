using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerApp.Interfaces;
using CrawlerApp.VK;
using Moq;
using NUnit.Framework;

namespace CrawlerTests
{
    [TestFixture]
    class GroupConverterTest
    {
        Mock<IWebClient> clientMock = new Mock<IWebClient>();
        
        const string Correct1 = "<a href=\"/photo-72495085_349884727\"";
        const string Correct2 = "1111111<a href=\"/photo-72495085_349884727\"1111";
        const string Correct3 = "/photo-<a href=\"/photo-72495085_349884727\"";

        private const string Correct4 =
            "<a href=\"/photo-30666517_350950328\" onclick=\"return showPhoto('-30666517_350950328',";
        private const string Correct5 =
            "<a href=\"/photo-30666517_111111111\" onclick=\"return showPhoto('-111111111_350950328',";
        private const string Correct6 =
            "/photo-30666517буквы/photo-30666517цифры12424/photo-30666517спецсимволы!=-:%№#/photo-30666517";

        [TestCase(Correct1,Result = 72495085,TestName = "SimpleTest")]
        [TestCase(Correct2, Result = 72495085, TestName = "WithExtraNumbers")]
        [TestCase(Correct3, Result = 72495085, TestName = "WithExtraLetters")]
        [TestCase(Correct4, Result = 30666517, TestName = "WithJS")]
        [TestCase(Correct5, Result = 30666517, TestName = "WithJSAndNumbers")]
        [TestCase(Correct6, Result = 30666517, TestName = "WithSymbols")]
        public long ConvertCorrectStrings(string pageText)
        {
            clientMock.Setup(m => m.DownloadString(It.IsAny<string>())).Returns(pageText);

            var converter = new VkUrlConverter(clientMock.Object);

            return converter.GetGroupIdByUrl(null);
        }

        const string Incorrect1 = "";
        const string Incorrect2 = "<a href=\"/photo-\"";
        const string Incorrect3 = "30666517";

        [TestCase(Incorrect1, Result = 0, TestName = "EmptyString")]
        [TestCase(Incorrect2, Result = 0, TestName = "WithoutNumbers")]
        [TestCase(Incorrect3, Result = 0, TestName = "OnlyNumbers")]
        public long ReturnZeroIfIncorrectString(string pageText)
        {
            clientMock.Setup(m => m.DownloadString(It.IsAny<string>())).Returns(pageText);

            var converter = new VkUrlConverter(clientMock.Object);

            return converter.GetGroupIdByUrl(null);
        }
    }
}
