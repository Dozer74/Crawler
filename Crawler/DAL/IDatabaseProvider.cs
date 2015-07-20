using System.Collections.Generic;

namespace CrawlerApp.DAL
{
    public interface IDatabaseProvider
    {
        void AddRecord(DataModel model);

        void SaveChanges();

        void Truncate();

        IEnumerable<DataModel> GetAllRecords();
    }
}