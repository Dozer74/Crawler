using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CrawlerApp.BL.Interfaces;
using CrawlerApp.DAL;

namespace CrawlerApp.UI
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
            IEnumerable<DataModel> records = dataProvider.GetAllRecords();

            if (!CheckForEmptyDatabase(records))
            {
                Close();
                return;
            }

            UpdateLabels(records);
            UpdateListView(records);
        }

        private void UpdateListView(IEnumerable<DataModel> records)
        {
            foreach (var record in records)
            {
                listView1.Items.Add(
                    new ListViewItem(new[] {FormatDateTime(record.UpdatingTime), record.MembersCount.ToString()}));
            }
        }

        private void UpdateLabels(IEnumerable<DataModel> records)
        {
            lbGroupUrl.Text = infoProvider.GetSavedGroupUrl();
            lbGroupname.Text = infoProvider.GetSavedGroupName();
            lbLastUpdate.Text = FormatDateTime(records.Max(r => r.UpdatingTime));
            lbRecordsCount.Text = records.Count().ToString();
        }

        private bool CheckForEmptyDatabase(IEnumerable<DataModel> records)
        {
            if (!records.Any())
            {
                MessageBox.Show("В базе нет записей!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToLongDateString() + " в " + dateTime.ToShortTimeString();
        }
    }
}
