namespace Blink_Camera_Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logBox = new System.Windows.Forms.GroupBox();
            this.forgetLbl = new System.Windows.Forms.LinkLabel();
            this.passLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.logBtn = new System.Windows.Forms.Button();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.verBox = new System.Windows.Forms.GroupBox();
            this.verText = new System.Windows.Forms.TextBox();
            this.verBtn = new System.Windows.Forms.Button();
            this.TabMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CameraContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ClipView = new System.Windows.Forms.DataGridView();
            this.imgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.OptionStrip = new System.Windows.Forms.MenuStrip();
            this.armSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDownloadedClipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logBox.SuspendLayout();
            this.verBox.SuspendLayout();
            this.TabMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClipView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.OptionStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Controls.Add(this.forgetLbl);
            this.logBox.Controls.Add(this.passLbl);
            this.logBox.Controls.Add(this.emailLbl);
            this.logBox.Controls.Add(this.logBtn);
            this.logBox.Controls.Add(this.passTxt);
            this.logBox.Controls.Add(this.emailTxt);
            this.logBox.Location = new System.Drawing.Point(279, 154);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(336, 155);
            this.logBox.TabIndex = 0;
            this.logBox.TabStop = false;
            this.logBox.Text = "Login";
            // 
            // forgetLbl
            // 
            this.forgetLbl.AutoSize = true;
            this.forgetLbl.Location = new System.Drawing.Point(82, 107);
            this.forgetLbl.Name = "forgetLbl";
            this.forgetLbl.Size = new System.Drawing.Size(92, 13);
            this.forgetLbl.TabIndex = 5;
            this.forgetLbl.TabStop = true;
            this.forgetLbl.Text = "Forgot Password?";
            this.forgetLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgetLbl_LinkClicked);
            // 
            // passLbl
            // 
            this.passLbl.AutoSize = true;
            this.passLbl.Location = new System.Drawing.Point(6, 79);
            this.passLbl.Name = "passLbl";
            this.passLbl.Size = new System.Drawing.Size(59, 13);
            this.passLbl.TabIndex = 4;
            this.passLbl.Text = "Password: ";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(27, 53);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(38, 13);
            this.emailLbl.TabIndex = 3;
            this.emailLbl.Text = "Email: ";
            // 
            // logBtn
            // 
            this.logBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBtn.AutoSize = true;
            this.logBtn.Location = new System.Drawing.Point(216, 102);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(74, 23);
            this.logBtn.TabIndex = 2;
            this.logBtn.Text = "Log In";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // passTxt
            // 
            this.passTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passTxt.Location = new System.Drawing.Point(85, 76);
            this.passTxt.Name = "passTxt";
            this.passTxt.PasswordChar = '*';
            this.passTxt.Size = new System.Drawing.Size(205, 20);
            this.passTxt.TabIndex = 1;
            // 
            // emailTxt
            // 
            this.emailTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTxt.Location = new System.Drawing.Point(85, 50);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(205, 20);
            this.emailTxt.TabIndex = 0;
            // 
            // verBox
            // 
            this.verBox.Controls.Add(this.verText);
            this.verBox.Controls.Add(this.verBtn);
            this.verBox.Location = new System.Drawing.Point(279, 154);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(336, 155);
            this.verBox.TabIndex = 1;
            this.verBox.TabStop = false;
            this.verBox.Text = "Verification Pin";
            this.verBox.Visible = false;
            // 
            // verText
            // 
            this.verText.Location = new System.Drawing.Point(126, 61);
            this.verText.Name = "verText";
            this.verText.Size = new System.Drawing.Size(100, 20);
            this.verText.TabIndex = 0;
            // 
            // verBtn
            // 
            this.verBtn.Location = new System.Drawing.Point(138, 87);
            this.verBtn.Name = "verBtn";
            this.verBtn.Size = new System.Drawing.Size(75, 23);
            this.verBtn.TabIndex = 1;
            this.verBtn.Text = "Verify";
            this.verBtn.UseVisualStyleBackColor = true;
            this.verBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // TabMenu
            // 
            this.TabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabMenu.Controls.Add(this.tabPage1);
            this.TabMenu.Controls.Add(this.tabPage2);
            this.TabMenu.Location = new System.Drawing.Point(0, 25);
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.SelectedIndex = 0;
            this.TabMenu.Size = new System.Drawing.Size(903, 537);
            this.TabMenu.TabIndex = 2;
            this.TabMenu.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CameraContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(895, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CameraContainer
            // 
            this.CameraContainer.AutoScroll = true;
            this.CameraContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraContainer.Location = new System.Drawing.Point(3, 3);
            this.CameraContainer.Name = "CameraContainer";
            this.CameraContainer.Size = new System.Drawing.Size(889, 505);
            this.CameraContainer.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ClipView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clips";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ClipView
            // 
            this.ClipView.AllowUserToAddRows = false;
            this.ClipView.AllowUserToDeleteRows = false;
            this.ClipView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClipView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ClipView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClipView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imgCol,
            this.nameCol,
            this.dateCol});
            this.ClipView.ContextMenuStrip = this.contextMenuStrip2;
            this.ClipView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClipView.Location = new System.Drawing.Point(3, 3);
            this.ClipView.Name = "ClipView";
            this.ClipView.ReadOnly = true;
            this.ClipView.Size = new System.Drawing.Size(889, 505);
            this.ClipView.TabIndex = 0;
            this.ClipView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClipView_CellContentClick);
            // 
            // imgCol
            // 
            this.imgCol.HeaderText = "Thumbnail";
            this.imgCol.Name = "imgCol";
            this.imgCol.ReadOnly = true;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Camera Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // dateCol
            // 
            this.dateCol.HeaderText = "Date";
            this.dateCol.Name = "dateCol";
            this.dateCol.ReadOnly = true;
            // 
            // LogoBox
            // 
            this.LogoBox.InitialImage = null;
            this.LogoBox.Location = new System.Drawing.Point(279, 25);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(336, 123);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 3;
            this.LogoBox.TabStop = false;
            // 
            // OptionStrip
            // 
            this.OptionStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.armSystemToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.viewDownloadedClipsToolStripMenuItem});
            this.OptionStrip.Location = new System.Drawing.Point(0, 0);
            this.OptionStrip.Name = "OptionStrip";
            this.OptionStrip.Size = new System.Drawing.Size(903, 24);
            this.OptionStrip.TabIndex = 4;
            this.OptionStrip.Text = "Options";
            // 
            // armSystemToolStripMenuItem
            // 
            this.armSystemToolStripMenuItem.Name = "armSystemToolStripMenuItem";
            this.armSystemToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.armSystemToolStripMenuItem.Text = "Arm System";
            this.armSystemToolStripMenuItem.Visible = false;
            this.armSystemToolStripMenuItem.Click += new System.EventHandler(this.armSystemToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Visible = false;
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewDownloadedClipsToolStripMenuItem
            // 
            this.viewDownloadedClipsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.viewDownloadedClipsToolStripMenuItem.Name = "viewDownloadedClipsToolStripMenuItem";
            this.viewDownloadedClipsToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.viewDownloadedClipsToolStripMenuItem.Text = "View Downloaded Clips";
            this.viewDownloadedClipsToolStripMenuItem.Click += new System.EventHandler(this.viewDownloadedClipsToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "\n";
            this.notifyIcon1.BalloonTipTitle = "Blink Camera Viewer";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Blink Camera Viewer";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 561);
            this.Controls.Add(this.TabMenu);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.verBox);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.OptionStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Blink Camera Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.logBox.ResumeLayout(false);
            this.logBox.PerformLayout();
            this.verBox.ResumeLayout(false);
            this.verBox.PerformLayout();
            this.TabMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClipView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.OptionStrip.ResumeLayout(false);
            this.OptionStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox logBox;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.GroupBox verBox;
        private System.Windows.Forms.Button verBtn;
        private System.Windows.Forms.TextBox verText;
        private System.Windows.Forms.Label passLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.LinkLabel forgetLbl;
        private System.Windows.Forms.TabControl TabMenu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel CameraContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView ClipView;
        private System.Windows.Forms.DataGridViewImageColumn imgCol;
        private System.Windows.Forms.DataGridViewImageColumn nameCol;
        private System.Windows.Forms.DataGridViewImageColumn dateCol;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.MenuStrip OptionStrip;
        private System.Windows.Forms.ToolStripMenuItem armSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewDownloadedClipsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}

