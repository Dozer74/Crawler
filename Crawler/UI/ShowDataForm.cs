using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crawler.DAL;

namespace Crawler.UI
{
    public partial class ShowDataForm : Form
    {
        private readonly IGroupInfoProvider infoProvider;
        private readonly IDatabaseProvider dataProvider;

        public ShowDataForm(IGroupInfoProvider infoProvider, IDatabaseProvider dataProvider)
        {
            this.infoProvider = infoProvider;
            this.dataProvider = dataProvider;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ShowDataForm_Load(object sender, EventArgs e)
        {
            var records = dataProvider.GetAllRecords();

            if (records.Count() == 0)
            {
                MessageBox.Show("В базе нет записей!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            lbGroupUrl.Text = infoProvider.GetSavedGroupUrl();
            lbGroupname.Text = infoProvider.GetSavedGroupName();
            lbLastUpdate.Text = FormatDateTime(records.Max(r => r.UpdatingTime));
            lbRecordsCount.Text = records.Count().ToString();

            foreach (var record in records)
            {
                listView1.Items.Add(
                    new ListViewItem(new[] {FormatDateTime(record.UpdatingTime), record.MembersCount.ToString()}));
            }
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToLongDateString() + " в " + dateTime.ToShortTimeString();
        }
    }
}
