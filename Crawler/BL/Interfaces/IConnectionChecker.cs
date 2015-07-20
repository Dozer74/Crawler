namespace CrawlerApp.BL.Interfaces
{
    public interface IConnectionChecker
    {
        /// <summary>
        /// Проверяет подключение компьютера к сети Интернет
        /// </summary>
        /// <returns>True, если подключен</returns>
        bool IsConnected();
    }
}