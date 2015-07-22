using System.Linq;
using CrawlerApp.Properties;

namespace CrawlerApp.DAL
{
    internal class EFGroupInfoProvider : IGroupInfoProvider
    {
        private readonly StatisticEntities db = new StatisticEntities();
        readonly Settings settings = Settings.Default;

        public bool IsGroupUrlSame(string groupUrl)
        {
            return string.Equals(groupUrl, settings.SavedGroupUrl);
            //return string.Equals(groupUrl, GetSavedGroupUrl());
        }

        public string GetSavedGroupUrl()
        {
            //return db.GroupInfo.FirstOrDefault()?.GroupUrl;
            return settings.SavedGroupUrl;
        }

        public string GetSavedGroupName()
        {
            //return db.GroupInfo.FirstOrDefault()?.GroupName;
            return settings.SavedGroupName;
        }

        public void UpdateGroupInfo(string groupName, string groupUrl)
        {
            var info = new GroupInfo
            {
                GroupName = groupName,
                GroupUrl = groupUrl
            };

            var currentInfo = db.GroupInfo.FirstOrDefault();
            if (currentInfo == null)
            {
                db.GroupInfo.Add(info);
            }
            else
            {
                currentInfo = info;//обновляем в БД
            }

            db.SaveChanges();

            settings.SavedGroupUrl = groupUrl;
            settings.SavedGroupName = groupName;
            settings.Save();
        }
    }
}