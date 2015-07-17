namespace Crawler.DAL
{
    public interface IDatabaseProvider
    {
        void AddRecord();

        void SaveChanges();

        void Truncate();
    }
}