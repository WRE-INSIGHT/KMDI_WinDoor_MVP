namespace PresentationLayer.Views.UserControls
{
    partial class BasePlatformUC
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
            this.pnl_frameDragDrop = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_frameDragDrop
            // 
            this.pnl_frameDragDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_frameDragDrop.Location = new System.Drawing.Point(70, 35);
            this.pnl_frameDragDrop.Name = "pnl_frameDragDrop";
            this.pnl_frameDragDrop.Size = new System.Drawing.Size(230, 265);
            this.pnl_frameDragDrop.TabIndex = 0;
            // 
            // BasePlatformUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_frameDragDrop);
            this.Name = "BasePlatformUC";
            this.Padding = new System.Windows.Forms.Padding(70, 35, 0, 0);
            this.Size = new System.Drawing.Size(300, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_frameDragDrop;
    }
}
