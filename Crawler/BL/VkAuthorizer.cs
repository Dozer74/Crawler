using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Crawler.BL.Enums;
using VkNet;

namespace Crawler.BL
{
    internal class VkAuthorizer
    {
        private readonly VkApi api;
        private readonly int appId;

        public VkAuthorizer(VkApi api, int appId)
        {
            this.api = api;
            this.appId = appId;
        }

        public void Login()
        {
            var browser = new WebBrowser {ScriptErrorsSuppressed = true};
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigate(
                string.Format(
                    "http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token",
                    appId, VkontakteScopeList.friends));

            while (browser.IsBusy)
            {
                Thread.Sleep(1000);
            }
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                var myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var accessToken = "";
                var userId = 0;
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        userId = Convert.ToInt32(m.Groups["value"].Value);
                    }
                }
                api.Authorize(accessToken, userId);
            }
        }
    }
}