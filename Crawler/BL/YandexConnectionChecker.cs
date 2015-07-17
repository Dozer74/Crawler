using System;
using System.Net;
using System.Net.NetworkInformation;
using Crawler.BL.Interfaces;

namespace Crawler.BL
{
    internal class YandexConnectionChecker : IConnectionChecker
    {
        public bool IsConnected()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }
            
            var client = new WebClient();
            try
            {
                var response = client.DownloadString("http://ya.ru/");
                return !string.IsNullOrEmpty(response);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}