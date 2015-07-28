using System;
using System.Net;
using CrawlerApp.Interfaces;

namespace CrawlerApp.Crawler
{
    internal class SimpleWebClient : IWebClient
    {
        public string DownloadString(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute) 
                ? DownloadString(new Uri(url)) 
                : null;
        }

        public string DownloadString(Uri url)
        {
            try
            {
                return new WebClient().DownloadString(url);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}