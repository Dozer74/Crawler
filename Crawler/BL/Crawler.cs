using Crawler.BL.Enums;
using Crawler.BL.Interfaces;

namespace Crawler.BL
{
    class Crawler : ICrawler
    {
        private readonly IConnectionChecker checker;
        private readonly IUrlConverter converter;
        private readonly IAuthorizer authorizer;

        public delegate void UpdateDelegate(MessageType type, string message);

        public event UpdateDelegate Update;

        public Crawler(IConnectionChecker checker, IUrlConverter converter, IAuthorizer authorizer)
        {
            this.checker = checker;
            this.converter = converter;
            this.authorizer = authorizer;
        }

        public void ProcessGroup(string url)
        {
            if (!checker.IsConnected())
            {
                Update(MessageType.Error, "Проблемы с Интернет соединением! :(");
                return;
            }
            Update(MessageType.Working, "Соединение с Интернет - ОК");

            var groupId = converter.GetGroupIdByUrl(url);
            if (groupId == -1)
            {
                Update(MessageType.Error, "Группа не найдена! :(");
                return;
            }
            Update(MessageType.Working, "Поиск группы - ОК");

            if (!authorizer.Login())
            {
                Update(MessageType.Error, "Группа не найдена! :(");
                return;
            }

        }


        #region Invocators

        protected virtual void OnUpdate(MessageType type, string message)
        {
            Update?.Invoke(type, message);
        }

        #endregion

    }
}
