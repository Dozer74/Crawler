using System;
using CrawlerApp.Crawler;
using CrawlerApp.DAL;
using CrawlerApp.DAL.Entity_Framework;
using CrawlerApp.DAL.Interfaces;
using CrawlerApp.Interfaces;
using CrawlerApp.VK;
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
            Bind<IWebClient>().To<SimpleWebClient>();

            Bind<IConnectionChecker>()
                .To<ConnectionChecker>()
                .WithConstructorArgument("urlForConnectionTest", new Uri("http://vk.com"));
            Bind<IUrlConverter>().To<VkUrlConverter>();
            Bind<IAuthorizer>().To<VkAuthorizer>()
                .WithConstructorArgument("appId", AppId)
                .WithConstructorArgument("userName", UserName)
                .WithConstructorArgument("password", Password);

            Bind<Crawler.Crawler>().ToSelf();
        }
    }
}