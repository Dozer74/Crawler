using System;
using System.Collections.Generic;
using System.Linq;
using CrawlerApp.DAL.Interfaces;

namespace CrawlerApp.DAL.Entity_Framework
{
    class EFDataProvider : IDatabaseProvider
    {
        private readonly StatisticEntities db;

        public EFDataProvider()
        {
            db = new StatisticEntities();
        }

        public bool AddRecord(DataModel model)
        {
            try
            {
                db.Statistic.Add(new Statistic
                {
                    Id = 0,
                    MembersCount = model.MembersCount,
                    UpdatingTime = model.UpdatingTime
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Truncate()
        {
            try
            {
                db.Statistic.RemoveRange(db.Statistic);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<DataModel> GetAllRecords()
        {
            return
                db.Statistic.ToList()
                    .Select(m => new DataModel {MembersCount = m.MembersCount, UpdatingTime = m.UpdatingTime});
        }
    }
}
