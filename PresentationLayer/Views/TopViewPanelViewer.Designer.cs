namespace PresentationLayer.Views
{
    partial class TopViewPanelViewer
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
            this.ts_TopViewPanelViewer = new System.Windows.Forms.ToolStrip();
            this.panel_topviewer = new System.Windows.Forms.Panel();
            this.pbox_TopView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_TopView)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_TopViewPanelViewer
            // 
            this.ts_TopViewPanelViewer.Location = new System.Drawing.Point(0, 0);
            this.ts_TopViewPanelViewer.Name = "ts_TopViewPanelViewer";
            this.ts_TopViewPanelViewer.Size = new System.Drawing.Size(753, 25);
            this.ts_TopViewPanelViewer.TabIndex = 0;
            this.ts_TopViewPanelViewer.Text = "toolStrip1";
            // 
            // panel_topviewer
            // 
            this.panel_topviewer.Location = new System.Drawing.Point(0, 28);
            this.panel_topviewer.Name = "panel_topviewer";
            this.panel_topviewer.Size = new System.Drawing.Size(753, 215);
            this.panel_topviewer.TabIndex = 2;
            this.panel_topviewer.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_topviewer_Paint);
            // 
            // pbox_TopView
            // 
            this.pbox_TopView.Location = new System.Drawing.Point(0, 242);
            this.pbox_TopView.Name = "pbox_TopView";
            this.pbox_TopView.Size = new System.Drawing.Size(753, 267);
            this.pbox_TopView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_TopView.TabIndex = 4;
            this.pbox_TopView.TabStop = false;
            // 
            // TopViewPanelViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 509);
            this.Controls.Add(this.pbox_TopView);
            this.Controls.Add(this.panel_topviewer);
            this.Controls.Add(this.ts_TopViewPanelViewer);
            this.Name = "TopViewPanelViewer";
            this.Text = "Panel Viewer (Top View)";
            this.Load += new System.EventHandler(this.TopViewPanelViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_TopView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_TopViewPanelViewer;
        private System.Windows.Forms.Panel panel_topviewer;
        private System.Windows.Forms.PictureBox pbox_TopView;
    }
}