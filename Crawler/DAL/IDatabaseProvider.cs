namespace Crawler.DAL
{
    public interface IDatabaseProvider
    {
        void AddRecord(DataModel model);

        void SaveChanges();

        void Truncate();
    }
}