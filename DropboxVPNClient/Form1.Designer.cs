namespace DropboxVPNClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gbSelectPath = new System.Windows.Forms.GroupBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtPathSelected = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.sContainer = new System.Windows.Forms.SplitContainer();
            this.optPanel = new System.Windows.Forms.Panel();
            this.gbSelectPath.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).BeginInit();
            this.sContainer.Panel1.SuspendLayout();
            this.sContainer.Panel2.SuspendLayout();
            this.sContainer.SuspendLayout();
            this.optPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectPath
            // 
            this.gbSelectPath.Controls.Add(this.cmdBrowse);
            this.gbSelectPath.Controls.Add(this.txtPathSelected);
            this.gbSelectPath.Location = new System.Drawing.Point(6, 41);
            this.gbSelectPath.Name = "gbSelectPath";
            this.gbSelectPath.Size = new System.Drawing.Size(319, 48);
            this.gbSelectPath.TabIndex = 24;
            this.gbSelectPath.TabStop = false;
            this.gbSelectPath.Text = "Select Folder";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(274, 18);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(26, 20);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            // 
            // txtPathSelected
            // 
            this.txtPathSelected.Location = new System.Drawing.Point(18, 19);
            this.txtPathSelected.Name = "txtPathSelected";
            this.txtPathSelected.Size = new System.Drawing.Size(250, 20);
            this.txtPathSelected.TabIndex = 0;
            this.txtPathSelected.Text = "\\\\192.168.0.4\\Data\\DropboxVNC";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.lblStatus);
            this.GroupBox4.Location = new System.Drawing.Point(340, 41);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(308, 46);
            this.GroupBox4.TabIndex = 23;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(19, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(263, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Inactive";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(262, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 23);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbVideo
            // 
            this.pbVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVideo.Location = new System.Drawing.Point(0, 0);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(661, 350);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 25;
            this.pbVideo.TabStop = false;
            this.pbVideo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbVideo_MouseDoubleClick);
            this.pbVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbVideo_MouseMove);
            this.pbVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVideo_MouseUp);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // sContainer
            // 
            this.sContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sContainer.IsSplitterFixed = true;
            this.sContainer.Location = new System.Drawing.Point(0, 0);
            this.sContainer.Name = "sContainer";
            this.sContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sContainer.Panel1
            // 
            this.sContainer.Panel1.Controls.Add(this.pbVideo);
            // 
            // sContainer.Panel2
            // 
            this.sContainer.Panel2.Controls.Add(this.optPanel);
            this.sContainer.Panel2MinSize = 114;
            this.sContainer.Size = new System.Drawing.Size(661, 468);
            this.sContainer.SplitterDistance = 350;
            this.sContainer.TabIndex = 26;
            // 
            // optPanel
            // 
            this.optPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optPanel.Controls.Add(this.btnStart);
            this.optPanel.Controls.Add(this.GroupBox4);
            this.optPanel.Controls.Add(this.gbSelectPath);
            this.optPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optPanel.Location = new System.Drawing.Point(0, 0);
            this.optPanel.Name = "optPanel";
            this.optPanel.Size = new System.Drawing.Size(661, 114);
            this.optPanel.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 468);
            this.Controls.Add(this.sContainer);
            this.Name = "Form1";
            this.Text = "DropBox VNC Client";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.gbSelectPath.ResumeLayout(false);
            this.gbSelectPath.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.sContainer.Panel1.ResumeLayout(false);
            this.sContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).EndInit();
            this.sContainer.ResumeLayout(false);
            this.optPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.GroupBox gbSelectPath;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.TextBox txtPathSelected;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer sContainer;
        private System.Windows.Forms.Panel optPanel;
    }
}

