namespace CrawlerApp.DAL
{
    public interface IGroupInfoProvider
    {
        bool IsGroupUrlSame(string groupName);

        string GetSavedGroupUrl();

        string GetSavedGroupName();

        void UpdateGroupInfo(string groupName, string groupUrl);
    }
}