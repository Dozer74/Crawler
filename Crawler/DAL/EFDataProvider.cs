
using System.Linq;

namespace Crawler.DAL
{
    class EFDataProvider : IDatabaseProvider
    {
        private readonly StatisticDbEntities db;

        public EFDataProvider()
        {
            db = new StatisticDbEntities();
        }

        public void AddRecord(DataModel model)
        {
            db.Statistic.Add(new Statistic
            {
                Id = 0,
                MembersCount = model.MembersCount,
                UpdatingTime = model.UpdatingTime
            });
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Truncate()
        {
            db.Statistic.SqlQuery("TRUNCATE TABLE [Statistic]");
        }
    }
}
