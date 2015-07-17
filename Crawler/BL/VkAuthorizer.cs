using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Crawler.BL.Enums;
using Crawler.BL.Interfaces;
using VkNet;

namespace Crawler.BL
{
    internal class VkAuthorizer : IAuthorizer
    {
        private readonly VkApi api;
        private readonly int appId;
        private ManualResetEvent handle;

        const int LoginWaitingTimeout = 10000;

        public VkAuthorizer(VkApi api, int appId)
        {
            this.api = api;
            this.appId = appId;
        }

        public bool Login()
        {
            handle = new ManualResetEvent(false);

            var thread = new Thread(() =>
            {
                var browser = new WebBrowser {ScriptErrorsSuppressed = true};
                browser.DocumentCompleted += Browser_DocumentCompleted;
                browser.Navigate(
                    string.Format(
                        "http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token",
                        appId, VkontakteScopeList.friends));
                Application.Run();
            });
            thread.SetApartmentState(ApartmentState.STA); //ActiveX-компонент WebBrowser'a может работать только в собственных апартаментах
            thread.Start();
            
            return handle.WaitOne(LoginWaitingTimeout) && !string.IsNullOrEmpty(api.AccessToken);
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                var regex = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

                string accessToken = "";
                int userId = 0;

                foreach (Match m in regex.Matches(e.Url.ToString()))
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
                handle.Set();
                Application.ExitThread();
            }
        }
    }
}