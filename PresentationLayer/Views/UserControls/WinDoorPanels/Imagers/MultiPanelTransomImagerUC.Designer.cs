namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    partial class MultiPanelTransomImagerUC
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
            this.flp_MultiTransomImager = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_MultiTransomImager
            // 
            this.flp_MultiTransomImager.AllowDrop = true;
            this.flp_MultiTransomImager.BackColor = System.Drawing.Color.White;
            this.flp_MultiTransomImager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_MultiTransomImager.Location = new System.Drawing.Point(0, 0);
            this.flp_MultiTransomImager.Margin = new System.Windows.Forms.Padding(0);
            this.flp_MultiTransomImager.Name = "flp_MultiTransomImager";
            this.flp_MultiTransomImager.Size = new System.Drawing.Size(300, 300);
            this.flp_MultiTransomImager.TabIndex = 2;
            this.flp_MultiTransomImager.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_MultiTransomImager_Paint);
            // 
            // MultiPanelTransomImagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flp_MultiTransomImager);
            this.Name = "MultiPanelTransomImagerUC";
            this.Size = new System.Drawing.Size(300, 300);
            this.VisibleChanged += new System.EventHandler(this.MultiPanelTransomImagerUC_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_MultiTransomImager;
    }
}
