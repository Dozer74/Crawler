using System;
using System.Windows.Forms;
using Crawler.BL.Enums;
using Crawler.DAL;
using Crawler.Properties;
using Ninject;

namespace Crawler.UI
{
    public partial class CrawlerForm : Form
    {
        readonly IKernel kernel = new StandardKernel(new SettingsNinjectModule());
        private readonly IGroupInfoProvider infoProvider;


        public CrawlerForm()
        {
            InitializeComponent();
            cbSearchParams.SelectedIndex = 0;
            infoProvider = kernel.Get<IGroupInfoProvider>();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lbStatus.Items.Clear();

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

                var dataProvider = kernel.Get<IDatabaseProvider>();
                dataProvider.Truncate();
            }
            return true;
        }

        private void Crawler_Update(MessageType type, string message)
        {
            lbStatus.Items.Add(message);
        }

        private void CrawlerForm_Load(object sender, EventArgs e)
        {
            tbGroupUrl.Text = infoProvider.GetSavedGroupUrl();
        }
    }
}
