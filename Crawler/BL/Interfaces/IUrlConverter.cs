using VkNet.Model;

namespace CrawlerApp.BL.Interfaces
{
    public interface IUrlConverter
    {
        Group GetGroupByUrl(string url);
    }
}