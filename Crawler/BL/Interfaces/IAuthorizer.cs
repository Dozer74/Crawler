namespace CrawlerApp.BL.Interfaces
{
    public interface IAuthorizer
    {
        /// <summary>
        /// Осуществляет попытку входа на сайт
        /// </summary>
        /// <returns>True, если удалось войти</returns>
        bool Login();
    }
}