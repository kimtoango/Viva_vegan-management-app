namespace Viva_vegan
{
    partial class HienThiChiTiet
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
            this.picBoxZoom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxZoom
            // 
            this.picBoxZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxZoom.Location = new System.Drawing.Point(0, 0);
            this.picBoxZoom.Name = "picBoxZoom";
            this.picBoxZoom.Size = new System.Drawing.Size(493, 576);
            this.picBoxZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxZoom.TabIndex = 0;
            this.picBoxZoom.TabStop = false;
            // 
            // HienThiChiTiet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(493, 576);
            this.Controls.Add(this.picBoxZoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HienThiChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HienThiChiTiet";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxZoom;
    }
}