namespace Viva_vegan
{
    partial class Greeting
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
            this.picBoxLoading = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxLoading
            // 
            this.picBoxLoading.BackColor = System.Drawing.Color.Transparent;
            this.picBoxLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxLoading.Image = global::Viva_vegan.Properties.Resources.Plant_spinner;
            this.picBoxLoading.Location = new System.Drawing.Point(97, 33);
            this.picBoxLoading.Name = "picBoxLoading";
            this.picBoxLoading.Size = new System.Drawing.Size(193, 304);
            this.picBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxLoading.TabIndex = 0;
            this.picBoxLoading.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Brush Script MT", 45F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(50, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading . . .";
            // 
            // Greeting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(418, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Greeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Greeting";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxLoading;
        private System.Windows.Forms.Label label1;
    }
}