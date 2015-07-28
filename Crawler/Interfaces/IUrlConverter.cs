using VkNet.Model;

namespace CrawlerApp.Interfaces
{
    public interface IUrlConverter
    {
        /// <summary>
        /// Осуществляет преобразование url в структуру VkNet.Group
        /// </summary>
        /// <returns>Null, если не удалось найти группу</returns>
        Group GetGroupByUrl(string url);
    }
}