using CrawlerApp.Interfaces;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;

namespace CrawlerApp.VK
{
    internal class VkAuthorizer : IAuthorizer
    {
        private readonly VkApi api;
        private readonly int appId;
        private readonly string userName;
        private readonly string password;

        public VkAuthorizer(VkApi api, int appId, string userName, string password)
        {
            this.api = api;
            this.appId = appId;
            this.userName = userName;
            this.password = password;
        }

        public bool Login()
        {
            api.Authorize(appId,userName,password,Settings.Groups);
            try
            {
                var user = api.Users.Get(1);
            }
            catch (AccessTokenInvalidException)
            {
                return false;
            }
            return true;
        }
        
    }
}