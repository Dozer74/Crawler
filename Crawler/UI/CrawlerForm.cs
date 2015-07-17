using System;
using System.Windows.Forms;
using Crawler.BL.Enums;
using Crawler.DAL;
using Ninject;

namespace Crawler.UI
{
    public partial class CrawlerForm : Form
    {
        readonly IKernel kernel = new StandardKernel(new SettingsNinjectModule());

        public CrawlerForm()
        {
            InitializeComponent();
            cbSearchParams.SelectedIndex = 0;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lbStatus.Items.Clear();

            var crawler = kernel.Get<BL.Crawler>();
            crawler.Update += Crawler_Update;

            crawler.ProcessGroup(tbGroupUrl.Text);
        }

        private void Crawler_Update(MessageType type, string message)
        {
            lbStatus.Items.Add(message);
        }

        private void CrawlerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
