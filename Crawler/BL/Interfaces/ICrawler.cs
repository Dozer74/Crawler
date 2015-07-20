﻿namespace CrawlerApp.BL.Interfaces
{
    public interface ICrawler
    {
        /// <summary>
        /// Обрабатывает данные указанной группы и сохраняет результаты в базу данных
        /// </summary>
        void ProcessGroup(string url);
    }
}