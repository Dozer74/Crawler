namespace Crawler.UI
{
    partial class ShowDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLastUpdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGroupname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGroupUrl = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сейчас в базе:";
            // 
            // lbRecordsCount
            // 
            this.lbRecordsCount.AutoSize = true;
            this.lbRecordsCount.Location = new System.Drawing.Point(147, 9);
            this.lbRecordsCount.Name = "lbRecordsCount";
            this.lbRecordsCount.Size = new System.Drawing.Size(0, 13);
            this.lbRecordsCount.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Последнее обновление:";
            // 
            // lbLastUpdate
            // 
            this.lbLastUpdate.AutoSize = true;
            this.lbLastUpdate.Location = new System.Drawing.Point(147, 22);
            this.lbLastUpdate.Name = "lbLastUpdate";
            this.lbLastUpdate.Size = new System.Drawing.Size(0, 13);
            this.lbLastUpdate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Информация о группе:";
            // 
            // lbGroupname
            // 
            this.lbGroupname.Location = new System.Drawing.Point(147, 48);
            this.lbGroupname.Name = "lbGroupname";
            this.lbGroupname.Size = new System.Drawing.Size(125, 43);
            this.lbGroupname.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Адрес группы:";
            // 
            // lbGroupUrl
            // 
            this.lbGroupUrl.AutoSize = true;
            this.lbGroupUrl.Location = new System.Drawing.Point(147, 35);
            this.lbGroupUrl.Name = "lbGroupUrl";
            this.lbGroupUrl.Size = new System.Drawing.Size(0, 13);
            this.lbGroupUrl.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(15, 94);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(257, 221);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Дата";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Подписчиков";
            this.columnHeader2.Width = 89;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 348);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbGroupUrl);
            this.Controls.Add(this.lbGroupname);
            this.Controls.Add(this.lbLastUpdate);
            this.Controls.Add(this.lbRecordsCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShowDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowDataForm";
            this.Load += new System.EventHandler(this.ShowDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLastUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbGroupname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbGroupUrl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
    }
}