namespace CrawlerApp.Interfaces
{
    public interface ICrawler
    {
        /// <summary>
        /// Обрабатывает данные указанной группы и сохраняет результаты в базу данных
        /// </summary>
        void ProcessGroup(string url);

        void ProcessGroupAsync(string url);
    }
}