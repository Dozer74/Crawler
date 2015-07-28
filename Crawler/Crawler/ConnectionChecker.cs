using System;
using CrawlerApp.Interfaces;

namespace CrawlerApp.Crawler
{
    public class ConnectionChecker : IConnectionChecker
    {
        private readonly Uri urlForConnectionTest;
        private readonly IWebClient webClient;

        public ConnectionChecker(Uri urlForConnectionTest, IWebClient webClient)
        {
            this.urlForConnectionTest = urlForConnectionTest;
            this.webClient = webClient;
        }

        public bool IsConnected()
        {
            var response = webClient.DownloadString(urlForConnectionTest);
            return !string.IsNullOrEmpty(response);
        }
    }
}