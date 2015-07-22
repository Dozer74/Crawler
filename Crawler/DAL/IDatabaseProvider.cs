using System.Collections.Generic;

namespace CrawlerApp.DAL
{
    public interface IDatabaseProvider
    {
        /// <summary>
        /// Добавляет указанную модель в базу данных
        /// </summary>
        bool AddRecord(DataModel model);

        /// <summary>
        /// Сохраняет все произведенные изменения
        /// </summary>
        bool SaveChanges();

        /// <summary>
        /// Очищает базу данных
        /// </summary>
        bool Truncate();

        /// <summary>
        /// Возвращает все хранящиеся в базе модели
        /// </summary>
        IEnumerable<DataModel> GetAllRecords();
    }
}