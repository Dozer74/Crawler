using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using CrawlerApp.Interfaces;
using VkNet;
using VkNet.Enums.Filters;
using Group = VkNet.Model.Group;

namespace CrawlerApp.VK
{
    internal class VkUrlConverter : IUrlConverter
    {
        private readonly VkApi api;

        public VkUrlConverter(VkApi api)
        {
            this.api = api;
        }

        public Group GetGroupByUrl(string url)
        {
            var regex = new Regex(@"(?<=/photo-)\d+", RegexOptions.Compiled);
            var client = new WebClient {Encoding = Encoding.UTF8};
            try
            {
                var data = client.DownloadString(url);
                var groupId = long.Parse(regex.Match(data).Value);
                return api.Groups.GetById(groupId, GroupsFields.MembersCount);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}