using VkNet;
using VkNet.Model;

namespace Crawler.BL.Interfaces
{
    public interface IUrlConverter
    {
        Group GetGroupByUrl(string url);
    }
}