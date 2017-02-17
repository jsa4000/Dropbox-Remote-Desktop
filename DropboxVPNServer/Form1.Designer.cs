namespace DropboxVPNServer
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
            this.btnStart = new System.Windows.Forms.Button();
            this.gbSelectPath = new System.Windows.Forms.GroupBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtPathSelected = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnScreen = new System.Windows.Forms.Button();
            this.btnMouse = new System.Windows.Forms.Button();
            this.tmrInput = new System.Windows.Forms.Timer(this.components);
            this.gbSelectPath.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(94, 131);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbSelectPath
            // 
            this.gbSelectPath.Controls.Add(this.cmdBrowse);
            this.gbSelectPath.Controls.Add(this.txtPathSelected);
            this.gbSelectPath.Location = new System.Drawing.Point(12, 12);
            this.gbSelectPath.Name = "gbSelectPath";
            this.gbSelectPath.Size = new System.Drawing.Size(319, 48);
            this.gbSelectPath.TabIndex = 20;
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
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
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
            this.GroupBox4.Location = new System.Drawing.Point(23, 69);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(308, 46);
            this.GroupBox4.TabIndex = 19;
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
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(261, 131);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(75, 23);
            this.btnScreen.TabIndex = 21;
            this.btnScreen.Text = "Screen";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // btnMouse
            // 
            this.btnMouse.Location = new System.Drawing.Point(13, 131);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(75, 23);
            this.btnMouse.TabIndex = 22;
            this.btnMouse.Text = "Screen";
            this.btnMouse.UseVisualStyleBackColor = true;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // tmrInput
            // 
            this.tmrInput.Tick += new System.EventHandler(this.tmrInput_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 167);
            this.Controls.Add(this.btnMouse);
            this.Controls.Add(this.btnScreen);
            this.Controls.Add(this.gbSelectPath);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Dropbox VPN Server";
            this.gbSelectPath.ResumeLayout(false);
            this.gbSelectPath.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.GroupBox gbSelectPath;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.TextBox txtPathSelected;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.Timer tmrInput;
    }
}

