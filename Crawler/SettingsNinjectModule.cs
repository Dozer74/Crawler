using Crawler.BL;
using Crawler.BL.Interfaces;
using Ninject;
using Ninject.Modules;

namespace Crawler
{
    public class SettingsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConnectionChecker>().To<YandexConnectionChecker>();
            Bind<IUrlConverter>().To<VkUrlConverter>();
            Bind<BL.Crawler>().ToSelf();
        }
    }
}