﻿using System;
using System.Net;
using System.Net.NetworkInformation;
using Crawler.BL.Interfaces;

namespace Crawler.BL
{
    internal class ConnectionChecker : IConnectionChecker
    {
        private readonly Uri urlForConnectionTest;

        public ConnectionChecker(Uri urlForConnectionTest)
        {
            this.urlForConnectionTest = urlForConnectionTest;
        }

        public bool IsConnected()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }
            
            var client = new WebClient();
            try
            {
                var response = client.DownloadString(urlForConnectionTest);
                return !string.IsNullOrEmpty(response);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}