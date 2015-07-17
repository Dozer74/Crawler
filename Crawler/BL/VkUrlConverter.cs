using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Crawler.BL.Interfaces;

namespace Crawler.BL
{
    internal class VkUrlConverter : IUrlConverter
    {
        public long GetGroupIdByUrl(string url)
        {
            var regex = new Regex(@"(?<=/photo-)\d+", RegexOptions.Compiled);
            var client = new WebClient {Encoding = Encoding.UTF8};
            try
            {
                var data = client.DownloadString(url);
                var groupId = long.Parse(regex.Match(data).Value);
                return groupId;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}