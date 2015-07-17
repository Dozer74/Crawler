using System;
using Crawler.BL.Enums;
using Crawler.BL.Interfaces;
using Crawler.DAL;

namespace Crawler.BL
{
    class Crawler : ICrawler
    {
        private readonly IConnectionChecker checker;
        private readonly IUrlConverter converter;
        private readonly IAuthorizer authorizer;
        private readonly IDatabaseProvider provider;

        public delegate void UpdateDelegate(MessageType type, string message);

        public event UpdateDelegate Update;

        public Crawler(IConnectionChecker checker, IUrlConverter converter, IAuthorizer authorizer, IDatabaseProvider provider)
        {
            this.checker = checker;
            this.converter = converter;
            this.authorizer = authorizer;
            this.provider = provider;
        }

        public void ProcessGroup(string url)
        {
            if (!checker.IsConnected())
            {
                Update(MessageType.Error, "Проблемы с Интернет соединением! :(");
                return;
            }
            Update(MessageType.Working, "Соединение с Интернет - ОК");

            if (!authorizer.Login())
            {
                Update(MessageType.Error, "Не удаётся залогиниться! :(");
                return;
            }
            Update(MessageType.Working, "Вход на сайт - ОК");

            var group = converter.GetGroupByUrl(url);
            if (group == null)
            {
                Update(MessageType.Error, "Группа не найдена! :(");
                return;
            }
            Update(MessageType.Working, "Поиск группы - ОК");

            Update(MessageType.Working, "Собираю информацию...");
            var data = new DataModel
            {
                MembersCount = group.MembersCount ?? 0,
                UpdatingTime = DateTime.Now
            };

            provider.AddRecord(data);
            provider.SaveChanges();
            Update(MessageType.Complited, "База успешно обновлена!");
        }

        #region Invocators

        protected virtual void OnUpdate(MessageType type, string message)
        {
            Update?.Invoke(type, message);
        }

        #endregion

    }
}
