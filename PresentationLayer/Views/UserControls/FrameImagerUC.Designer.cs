namespace PresentationLayer.Views.UserControls
{
    partial class FrameImagerUC
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
            // FrameImagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FrameImagerUC";
            this.Padding = new System.Windows.Forms.Padding(26);
            this.Size = new System.Drawing.Size(100, 100);
            this.Load += new System.EventHandler(this.FrameImagerUC_Load);
            this.PaddingChanged += new System.EventHandler(this.FrameImagerUC_PaddingChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameImagerUC_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
