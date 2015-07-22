using System;
using CrawlerApp.BL;
using CrawlerApp.BL.Interfaces;
using CrawlerApp.DAL;
using Ninject.Modules;
using VkNet;

namespace CrawlerApp
{
    public class SettingsNinjectModule : NinjectModule
    {
        const int AppId = 4988419; 
        private const string UserName = "VKCrawler@yandex.ru";
        private const string Password = "qwaszxerdfcv1234"; // Данные для авторизации на сайте ВКонтакте

        public override void Load()
        {
            Bind<VkApi>().ToSelf().InSingletonScope();

            Bind<IDatabaseProvider>().To<EFDataProvider>();
            Bind<IGroupInfoProvider>().To<EFGroupInfoProvider>();

            Bind<IConnectionChecker>()
                .To<ConnectionChecker>()
                .WithConstructorArgument("urlForConnectionTest", new Uri("http://vk.com"));
            Bind<IUrlConverter>().To<VkUrlConverter>();
            Bind<IAuthorizer>().To<VkAuthorizer>()
                .WithConstructorArgument("appId", AppId)
                .WithConstructorArgument("userName", UserName)
                .WithConstructorArgument("password", Password);

            Bind<BL.Crawler>().ToSelf();
        }
    }
}