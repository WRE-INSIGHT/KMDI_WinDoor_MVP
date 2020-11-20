namespace PresentationLayer.Views.UserControls
{
    partial class FrameUC
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
            this.pnl_inner = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_inner
            // 
            this.pnl_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_inner.Location = new System.Drawing.Point(26, 26);
            this.pnl_inner.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_inner.Name = "pnl_inner";
            this.pnl_inner.Size = new System.Drawing.Size(248, 248);
            this.pnl_inner.TabIndex = 0;
            this.pnl_inner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_inner_Paint);
            // 
            // FrameUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_inner);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FrameUC";
            this.Padding = new System.Windows.Forms.Padding(26);
            this.Size = new System.Drawing.Size(300, 300);
            this.Load += new System.EventHandler(this.FrameUC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameUC_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_inner;
    }
}
