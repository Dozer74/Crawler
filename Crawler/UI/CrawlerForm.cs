using System;
using System.Diagnostics;
using System.Windows.Forms;
using CrawlerApp.Crawler;
using CrawlerApp.DAL;
using CrawlerApp.DAL.Interfaces;
using CrawlerApp.Interfaces;
using CrawlerApp.Properties;
using Ninject;

namespace CrawlerApp.UI
{
    public partial class CrawlerForm : Form
    {
        private readonly IConnectionChecker connection;
        private readonly IDatabaseProvider dataProvider;
        private readonly IGroupInfoProvider infoProvider;
        private readonly IKernel kernel = new StandardKernel(new SettingsNinjectModule());

        public CrawlerForm()
        {
            InitializeComponent();
            cbSearchParams.SelectedIndex = 0;
            infoProvider = kernel.Get<IGroupInfoProvider>();
            dataProvider = kernel.Get<IDatabaseProvider>();
            connection = kernel.Get<IConnectionChecker>();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            listViewStatus.Items.Clear();
            ChangeBtnStartState(false);

            if (!ContinueIfGroupsNotSame())
                return;

            var crawler = kernel.Get<Crawler.Crawler>();
            crawler.Update += Crawler_Update;

            crawler.ProcessGroupAsync(tbGroupUrl.Text);
        }

        private void ChangeBtnStartState(bool state)
        {
            btnStart.Text = state ? "Старт!" : "Working...";
            btnStart.Enabled = state;
        }

        private bool ContinueIfGroupsNotSame()
        {
            if (!infoProvider.IsGroupUrlSame(tbGroupUrl.Text))
            {
                if (MessageBox.Show(Resources.NewGroupMessage, "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    != DialogResult.OK)
                {
                    tbGroupUrl.Text = infoProvider.GetSavedGroupUrl();
                    tbGroupUrl.Focus();
                    return false;
                }
                dataProvider.Truncate();
            }
            return true;
        }

        private void Crawler_Update(MessageType type, string message)
        {
            Invoke(new Action(() =>
                {
                    listViewStatus.Items.Add(new ListViewItem(message) {StateImageIndex = (int) type});
                    if (type != MessageType.Working)
                        ChangeBtnStartState(true);
                }));
        }

        private void CrawlerForm_Load(object sender, EventArgs e)
        {
            tbGroupUrl.Text = infoProvider.GetSavedGroupUrl();
        }

        private void TrancuteMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;
            dataProvider.Truncate();
        }

        private void ShowDataMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;
            var form = new ShowDataForm(infoProvider, dataProvider);
            form.ShowDialog();
        }

        private bool CheckConnection()
        {
            if (!connection.IsConnected())
            {
                MessageBox.Show("Проблемы с Интернет соединением!", "Внимание!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LaunchWebSiteMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://vkcrawler.azurewebsites.net/");
        }
    }
}