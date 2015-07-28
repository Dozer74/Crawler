using System;
using System.Threading;
using CrawlerApp.DAL;
using CrawlerApp.DAL.Interfaces;
using CrawlerApp.Interfaces;
using VkNet;
using VkNet.Enums.Filters;

namespace CrawlerApp.Crawler
{
    public class Crawler : ICrawler
    {
        private readonly VkApi api;
        private readonly IConnectionChecker checker;
        private readonly IUrlConverter converter;
        private readonly IAuthorizer authorizer;
        private readonly IDatabaseProvider dbProvider;
        private readonly IGroupInfoProvider groupInfoProvider;

        public delegate void UpdateDelegate(MessageType type, string message);

        public event UpdateDelegate Update;

        public Crawler(VkApi api, IConnectionChecker checker, IAuthorizer authorizer, IUrlConverter converter, IDatabaseProvider databaseDbProvider, IGroupInfoProvider groupInfoProvider)
        {
            this.api = api;
            this.checker = checker;
            this.converter = converter;
            this.authorizer = authorizer;
            this.dbProvider = databaseDbProvider;
            this.groupInfoProvider = groupInfoProvider;
        }

        public void ProcessGroup(string url)
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

            var groupId = converter.GetGroupIdByUrl(url);
            if (groupId == 0)
            {
                OnUpdate(MessageType.Error, "Группа не найдена! :(");
                return;
            }
            OnUpdate(MessageType.Working, "Поиск группы - ОК");

            var group = api.Groups.GetById(groupId, GroupsFields.MembersCount);

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
        }

        public void ProcessGroupAsync(string url)
        {
            new Thread(ProcessGroup).Start(url);
        }


        private void ProcessGroup(object url)
        {
            ProcessGroup((string)url);
        }

        #region Invocators

        protected virtual void OnUpdate(MessageType type, string message)
        {
            Update?.Invoke(type, message);
        }

#endregion

    }
}
