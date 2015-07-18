﻿using System.Linq;

namespace Crawler.DAL
{
    internal class EFGroupInfoProvider : IGroupInfoProvider
    {
        private readonly StatisticDbEntities db = new StatisticDbEntities();

        public bool IsGroupUrlSame(string groupName)
        {
            return string.Equals(groupName, GetSavedGroupUrl());
        }

        public string GetSavedGroupUrl()
        {
            return db.GroupInfo.FirstOrDefault()?.GroupUrl;
        }

        public string GetSavedGroupName()
        {
            return db.GroupInfo.FirstOrDefault()?.GroupName;
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
                currentInfo = info;
                //db.Entry(currentInfo).State = EntityState.Modified;
            }

            db.SaveChanges();
        }
    }
}