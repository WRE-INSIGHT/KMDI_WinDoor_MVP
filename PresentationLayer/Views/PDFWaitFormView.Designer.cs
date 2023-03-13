namespace PresentationLayer.Views
{
    partial class PDFWaitFormView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Pwait = new System.Windows.Forms.Label();
            this.lbl_image = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_Pwait);
            this.panel1.Controls.Add(this.lbl_image);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 100);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Pwait
            // 
            this.lbl_Pwait.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwait.Location = new System.Drawing.Point(96, 39);
            this.lbl_Pwait.Name = "lbl_Pwait";
            this.lbl_Pwait.Size = new System.Drawing.Size(114, 21);
            this.lbl_Pwait.TabIndex = 1;
            this.lbl_Pwait.Text = "Please Wait...";
            // 
            // lbl_image
            // 
            this.lbl_image.BackColor = System.Drawing.Color.Transparent;
            this.lbl_image.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_image.Image = global::PresentationLayer.Properties.Resources.fade90;
            this.lbl_image.Location = new System.Drawing.Point(0, 0);
            this.lbl_image.Name = "lbl_image";
            this.lbl_image.Size = new System.Drawing.Size(98, 98);
            this.lbl_image.TabIndex = 0;
            // 
            // PDFWaitFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(215, 100);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PDFWaitFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFWaitFormView";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Pwait;
        private System.Windows.Forms.Label lbl_image;
    }
}