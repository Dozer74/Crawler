namespace CrawlerApp.UI
{
    partial class CrawlerForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrawlerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbGroupUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSearchParams = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewStatus = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrancuteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchWebSiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(62, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 52);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(56, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "VK Crawler";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnStart.Location = new System.Drawing.Point(57, 226);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(203, 33);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Старт!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbGroupUrl
            // 
            this.tbGroupUrl.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tbGroupUrl.Location = new System.Drawing.Point(20, 108);
            this.tbGroupUrl.Name = "tbGroupUrl";
            this.tbGroupUrl.Size = new System.Drawing.Size(286, 33);
            this.tbGroupUrl.TabIndex = 8;
            this.tbGroupUrl.Text = "https://vk.com/susu_vmi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "URL группы:";
            // 
            // cbSearchParams
            // 
            this.cbSearchParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchParams.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cbSearchParams.FormattingEnabled = true;
            this.cbSearchParams.Items.AddRange(new object[] {
            "Число подписчиков"});
            this.cbSearchParams.Location = new System.Drawing.Point(17, 184);
            this.cbSearchParams.Name = "cbSearchParams";
            this.cbSearchParams.Size = new System.Drawing.Size(289, 33);
            this.cbSearchParams.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Что ищем?";
            // 
            // listViewStatus
            // 
            this.listViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewStatus.GridLines = true;
            this.listViewStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewStatus.Location = new System.Drawing.Point(50, 265);
            this.listViewStatus.Name = "listViewStatus";
            this.listViewStatus.Size = new System.Drawing.Size(217, 93);
            this.listViewStatus.StateImageList = this.imageList1;
            this.listViewStatus.TabIndex = 14;
            this.listViewStatus.UseCompatibleStateImageBehavior = false;
            this.listViewStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 210;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            this.imageList1.Images.SetKeyName(1, "error.png");
            this.imageList1.Images.SetKeyName(2, "ok.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.LaunchWebSiteMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrancuteMenuItem,
            this.ShowDataMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // TrancuteMenuItem
            // 
            this.TrancuteMenuItem.Name = "TrancuteMenuItem";
            this.TrancuteMenuItem.Size = new System.Drawing.Size(182, 22);
            this.TrancuteMenuItem.Text = "Очистить базу";
            this.TrancuteMenuItem.Click += new System.EventHandler(this.TrancuteMenuItem_Click);
            // 
            // ShowDataMenuItem
            // 
            this.ShowDataMenuItem.Name = "ShowDataMenuItem";
            this.ShowDataMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ShowDataMenuItem.Text = "Отобразить данные";
            this.ShowDataMenuItem.Click += new System.EventHandler(this.ShowDataMenuItem_Click);
            // 
            // LaunchWebSiteMenuItem
            // 
            this.LaunchWebSiteMenuItem.Name = "LaunchWebSiteMenuItem";
            this.LaunchWebSiteMenuItem.Size = new System.Drawing.Size(151, 20);
            this.LaunchWebSiteMenuItem.Text = "Открыть веб интерфейс";
            this.LaunchWebSiteMenuItem.Click += new System.EventHandler(this.LaunchWebSiteMenuItem_Click);
            // 
            // CrawlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 370);
            this.Controls.Add(this.listViewStatus);
            this.Controls.Add(this.cbSearchParams);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbGroupUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CrawlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VK Crawler";
            this.Load += new System.EventHandler(this.CrawlerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbGroupUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSearchParams;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewStatus;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrancuteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchWebSiteMenuItem;
    }
}

