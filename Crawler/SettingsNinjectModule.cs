using Crawler.BL;
using Crawler.BL.Interfaces;
using Crawler.DAL;
using Ninject.Modules;
using VkNet;

namespace Crawler
{
    public class SettingsNinjectModule : NinjectModule
    {
        const int AppId = 4988419; // Id приложения на сайте ВКонтакте

        public override void Load()
        {
            Bind<VkApi>().ToSelf().InSingletonScope();
            Bind<IDatabaseProvider>().To<EFDataProvider>();
            Bind<IGroupInfoProvider>().To<EFGroupInfoProvider>();
            Bind<IConnectionChecker>().To<YandexConnectionChecker>();
            Bind<IUrlConverter>().To<VkUrlConverter>();
            Bind<IAuthorizer>().To<VkAuthorizer>().WithConstructorArgument("appId", AppId);
            Bind<BL.Crawler>().ToSelf();
        }
    }
}