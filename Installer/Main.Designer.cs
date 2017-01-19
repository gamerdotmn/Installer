namespace Installer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_choose = new System.Windows.Forms.Label();
            this.radioButton_client = new System.Windows.Forms.RadioButton();
            this.radioButton_monitor = new System.Windows.Forms.RadioButton();
            this.radioButton_server = new System.Windows.Forms.RadioButton();
            this.button_install = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label_installing = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(35, 129);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 23);
            this.progressBar.TabIndex = 0;
            // 
            // label_choose
            // 
            this.label_choose.AutoSize = true;
            this.label_choose.Location = new System.Drawing.Point(30, 30);
            this.label_choose.Name = "label_choose";
            this.label_choose.Size = new System.Drawing.Size(51, 13);
            this.label_choose.TabIndex = 1;
            this.label_choose.Text = "Сонголт:";
            // 
            // radioButton_client
            // 
            this.radioButton_client.AutoSize = true;
            this.radioButton_client.Checked = true;
            this.radioButton_client.Location = new System.Drawing.Point(33, 60);
            this.radioButton_client.Name = "radioButton_client";
            this.radioButton_client.Size = new System.Drawing.Size(61, 17);
            this.radioButton_client.TabIndex = 1;
            this.radioButton_client.TabStop = true;
            this.radioButton_client.Text = "Клиент";
            this.radioButton_client.UseVisualStyleBackColor = true;
            // 
            // radioButton_monitor
            // 
            this.radioButton_monitor.AutoSize = true;
            this.radioButton_monitor.Location = new System.Drawing.Point(33, 83);
            this.radioButton_monitor.Name = "radioButton_monitor";
            this.radioButton_monitor.Size = new System.Drawing.Size(61, 17);
            this.radioButton_monitor.TabIndex = 2;
            this.radioButton_monitor.Text = "Хяналт";
            this.radioButton_monitor.UseVisualStyleBackColor = true;
            // 
            // radioButton_server
            // 
            this.radioButton_server.AutoSize = true;
            this.radioButton_server.Location = new System.Drawing.Point(33, 106);
            this.radioButton_server.Name = "radioButton_server";
            this.radioButton_server.Size = new System.Drawing.Size(62, 17);
            this.radioButton_server.TabIndex = 3;
            this.radioButton_server.Text = "Сервер";
            this.radioButton_server.UseVisualStyleBackColor = true;
            // 
            // button_install
            // 
            this.button_install.Location = new System.Drawing.Point(371, 158);
            this.button_install.Name = "button_install";
            this.button_install.Size = new System.Drawing.Size(75, 23);
            this.button_install.TabIndex = 5;
            this.button_install.Text = "Суулгах";
            this.button_install.UseVisualStyleBackColor = true;
            this.button_install.Click += new System.EventHandler(this.button_install_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Installer.Properties.Resources.image_1007767;
            this.pictureBox.Location = new System.Drawing.Point(192, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // label_installing
            // 
            this.label_installing.AutoSize = true;
            this.label_installing.Location = new System.Drawing.Point(152, 133);
            this.label_installing.Name = "label_installing";
            this.label_installing.Size = new System.Drawing.Size(177, 13);
            this.label_installing.TabIndex = 7;
            this.label_installing.Text = "Суулгаж байна, та түр хүлээнэ үү.";
            this.label_installing.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.label_installing);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button_install);
            this.Controls.Add(this.radioButton_server);
            this.Controls.Add(this.radioButton_monitor);
            this.Controls.Add(this.radioButton_client);
            this.Controls.Add(this.label_choose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "MasterCafe суулгах";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_choose;
        private System.Windows.Forms.RadioButton radioButton_client;
        private System.Windows.Forms.RadioButton radioButton_monitor;
        private System.Windows.Forms.RadioButton radioButton_server;
        private System.Windows.Forms.Button button_install;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_installing;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}