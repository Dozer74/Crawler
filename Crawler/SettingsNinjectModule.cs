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
        const int AppId = 4988419; // Id приложения на сайте ВКонтакте

        public override void Load()
        {
            Bind<VkApi>().ToSelf().InSingletonScope();

            Bind<IDatabaseProvider>().To<EFDataProvider>();
            Bind<IGroupInfoProvider>().To<EFGroupInfoProvider>();

            Bind<IConnectionChecker>()
                .To<ConnectionChecker>()
                .WithConstructorArgument("urlForConnectionTest", new Uri("http://vk.com"));
            Bind<IUrlConverter>().To<VkUrlConverter>();
            Bind<IAuthorizer>().To<VkAuthorizer>().WithConstructorArgument("appId", AppId);

            Bind<BL.Crawler>().ToSelf();
        }
    }
}