using System;
using System.Diagnostics;
using System.Windows.Forms;
using CrawlerApp.BL.Enums;
using CrawlerApp.BL.Interfaces;
using CrawlerApp.DAL;
using CrawlerApp.Properties;
using Ninject;

namespace CrawlerApp.UI
{
    public partial class CrawlerForm : Form
    {
        readonly IKernel kernel = new StandardKernel(new SettingsNinjectModule());
        private readonly IGroupInfoProvider infoProvider;
        private readonly IDatabaseProvider dataProvider;
        private readonly IConnectionChecker connection;


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

            if (!ContinueIfGroupsNotSame())
                return;

            var crawler = kernel.Get<BL.Crawler>();
            crawler.Update += Crawler_Update;

            crawler.ProcessGroup(tbGroupUrl.Text);
        }

        private bool ContinueIfGroupsNotSame()
        {
            if (!infoProvider.IsGroupUrlSame(tbGroupUrl.Text))
            {
                if (MessageBox.Show(Resources.NewGroupMessage,"Внимание!",
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
            listViewStatus.Items.Add(new ListViewItem(message) {StateImageIndex = (int) type});
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
            var form = new ShowDataForm(infoProvider,dataProvider);
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
