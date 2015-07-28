using System;

namespace CrawlerApp.Interfaces
{
    public interface IWebClient
    {
        string DownloadString(Uri url);

        string DownloadString(string url);
    }
}