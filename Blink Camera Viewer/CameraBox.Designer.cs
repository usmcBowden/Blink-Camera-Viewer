namespace Blink_Camera_Viewer
{
    partial class CameraBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb = new System.Windows.Forms.PictureBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.batteryLbl = new System.Windows.Forms.Label();
            this.enblLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(404, 198);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(3, 205);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(35, 13);
            this.nameLbl.TabIndex = 1;
            this.nameLbl.Text = "label1";
            // 
            // batteryLbl
            // 
            this.batteryLbl.AutoSize = true;
            this.batteryLbl.Location = new System.Drawing.Point(54, 205);
            this.batteryLbl.Name = "batteryLbl";
            this.batteryLbl.Size = new System.Drawing.Size(35, 13);
            this.batteryLbl.TabIndex = 2;
            this.batteryLbl.Text = "label2";
            // 
            // enblLbl
            // 
            this.enblLbl.AutoSize = true;
            this.enblLbl.Location = new System.Drawing.Point(111, 205);
            this.enblLbl.Name = "enblLbl";
            this.enblLbl.Size = new System.Drawing.Size(35, 13);
            this.enblLbl.TabIndex = 3;
            this.enblLbl.Text = "label3";
            // 
            // CameraBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enblLbl);
            this.Controls.Add(this.batteryLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.pb);
            this.Name = "CameraBox";
            this.Size = new System.Drawing.Size(404, 265);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label batteryLbl;
        private System.Windows.Forms.Label enblLbl;
    }
}
