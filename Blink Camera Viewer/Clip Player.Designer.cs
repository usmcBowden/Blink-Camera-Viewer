namespace Blink_Camera_Viewer
{
    partial class Clip_Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clip_Player));
            this.clipPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.clipPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // clipPlayer
            // 
            this.clipPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clipPlayer.Enabled = true;
            this.clipPlayer.Location = new System.Drawing.Point(0, 0);
            this.clipPlayer.Name = "clipPlayer";
            this.clipPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("clipPlayer.OcxState")));
            this.clipPlayer.Size = new System.Drawing.Size(793, 557);
            this.clipPlayer.TabIndex = 1;
            // 
            // Clip_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 557);
            this.Controls.Add(this.clipPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clip_Player";
            this.Text = "Clip Player";
            this.Load += new System.EventHandler(this.Clip_Player_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clipPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer clipPlayer;
    }
}