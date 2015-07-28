using System.Text.RegularExpressions;
using CrawlerApp.Interfaces;

namespace CrawlerApp.VK
{
    public class VkUrlConverter : IUrlConverter
    {
        private readonly IWebClient webClient;

        public VkUrlConverter(IWebClient webClient)
        {
            this.webClient = webClient;
        }
        
        public long GetGroupIdByUrl(string url)
        {
            var regex = new Regex(@"(?<=/photo-)\d+", RegexOptions.Compiled);

            var data = webClient.DownloadString(url);

            if (regex.IsMatch(data))
            {
                var groupId = long.Parse(regex.Match(data).Value);
                return groupId;
            }
            else return 0;

        }
    }
}