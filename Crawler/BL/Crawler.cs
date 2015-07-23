using System;
using System.Threading;
using CrawlerApp.BL.Enums;
using CrawlerApp.BL.Interfaces;
using CrawlerApp.DAL;

namespace CrawlerApp.BL
{
    public class Crawler : ICrawler
    {
        private readonly IConnectionChecker checker;
        private readonly IUrlConverter converter;
        private readonly IAuthorizer authorizer;
        private readonly IDatabaseProvider dbProvider;
        private readonly IGroupInfoProvider groupInfoProvider;

        public delegate void UpdateDelegate(MessageType type, string message);

        public event UpdateDelegate Update;

        public Crawler(IConnectionChecker checker, IAuthorizer authorizer, IUrlConverter converter, IDatabaseProvider databaseDbProvider, IGroupInfoProvider groupInfoProvider)
        {
            this.checker = checker;
            this.converter = converter;
            this.authorizer = authorizer;
            this.dbProvider = databaseDbProvider;
            this.groupInfoProvider = groupInfoProvider;
        }

        public void ProcessGroup(string url)
        {
            new Thread(() =>
            {
                if (!checker.IsConnected())
                {
                    OnUpdate(MessageType.Error, "Проблемы с Интернет соединением! :(");
                    return;
                }
                OnUpdate(MessageType.Working, "Соединение с Интернет - ОК");

                if (!authorizer.Login())
                {
                    OnUpdate(MessageType.Error, "Не удаётся залогиниться! :(");
                    return;
                }
                OnUpdate(MessageType.Working, "Вход на сайт - ОК");

                var group = converter.GetGroupByUrl(url);
                if (group == null)
                {
                    OnUpdate(MessageType.Error, "Группа не найдена! :(");
                    return;
                }
                OnUpdate(MessageType.Working, "Поиск группы - ОК");

                OnUpdate(MessageType.Working, "Собираю информацию...");
                var data = new DataModel
                {
                    MembersCount = group.MembersCount ?? 0,
                    UpdatingTime = DateTime.Now
                };

                dbProvider.AddRecord(data);
                dbProvider.SaveChanges();

                groupInfoProvider.UpdateGroupInfo(group.Name, url);

                OnUpdate(MessageType.Complited, "База успешно обновлена!");
            }).Start();
        }

        #region Invocators

        protected virtual void OnUpdate(MessageType type, string message)
        {
            Update?.Invoke(type, message);
        }

        #endregion

    }
}
