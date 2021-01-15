namespace PresentationLayer.Views.UserControls.Dividers
{
    partial class MullionUC
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
            this.SuspendLayout();
            // 
            // MullionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MullionUC";
            this.Size = new System.Drawing.Size(30, 350);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MullionUC_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
