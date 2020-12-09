namespace PresentationLayer.Views.UserControls
{
    partial class ControlsUC
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
            this.lblControlText = new System.Windows.Forms.Label();
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // lblControlText
            // 
            this.lblControlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblControlText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlText.Location = new System.Drawing.Point(0, 0);
            this.lblControlText.Name = "lblControlText";
            this.lblControlText.Size = new System.Drawing.Size(63, 63);
            this.lblControlText.TabIndex = 3;
            this.lblControlText.Text = "Fixed";
            this.lblControlText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbox_Image
            // 
            this.pbox_Image.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbox_Image.Location = new System.Drawing.Point(63, 0);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(65, 63);
            this.pbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_Image.TabIndex = 4;
            this.pbox_Image.TabStop = false;
            // 
            // ControlsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblControlText);
            this.Controls.Add(this.pbox_Image);
            this.Name = "ControlsUC";
            this.Size = new System.Drawing.Size(128, 63);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblControlText;
        private System.Windows.Forms.PictureBox pbox_Image;
    }
}
