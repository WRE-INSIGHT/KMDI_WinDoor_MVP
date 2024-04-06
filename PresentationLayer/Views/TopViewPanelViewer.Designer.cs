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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopViewPanelViewer));
            this.ts_TopViewPanelViewer = new System.Windows.Forms.ToolStrip();
            this.ts_newButton = new System.Windows.Forms.ToolStripButton();
            this.panel_topviewer = new System.Windows.Forms.Panel();
            this.pbox_panels = new System.Windows.Forms.PictureBox();
            this.pbox_TopView = new System.Windows.Forms.PictureBox();
            this.ts_TopViewPanelViewer.SuspendLayout();
            this.panel_topviewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_panels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_TopView)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_TopViewPanelViewer
            // 
            this.ts_TopViewPanelViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_newButton});
            this.ts_TopViewPanelViewer.Location = new System.Drawing.Point(0, 0);
            this.ts_TopViewPanelViewer.Name = "ts_TopViewPanelViewer";
            this.ts_TopViewPanelViewer.Size = new System.Drawing.Size(797, 25);
            this.ts_TopViewPanelViewer.TabIndex = 0;
            this.ts_TopViewPanelViewer.Text = "toolStrip1";
            // 
            // ts_newButton
            // 
            this.ts_newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_newButton.Image = ((System.Drawing.Image)(resources.GetObject("ts_newButton.Image")));
            this.ts_newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_newButton.Name = "ts_newButton";
            this.ts_newButton.Size = new System.Drawing.Size(23, 22);
            this.ts_newButton.Text = "Create New Top View";
            this.ts_newButton.Click += new System.EventHandler(this.TopViewPanelViewerNewButton_Clicked);
            // 
            // panel_topviewer
            // 
            this.panel_topviewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_topviewer.BackColor = System.Drawing.Color.White;
            this.panel_topviewer.Controls.Add(this.pbox_panels);
            this.panel_topviewer.Location = new System.Drawing.Point(0, 28);
            this.panel_topviewer.Name = "panel_topviewer";
            this.panel_topviewer.Size = new System.Drawing.Size(797, 281);
            this.panel_topviewer.TabIndex = 2;
            this.panel_topviewer.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_topviewer_Paint);
            // 
            // pbox_panels
            // 
            this.pbox_panels.Location = new System.Drawing.Point(77, 0);
            this.pbox_panels.Name = "pbox_panels";
            this.pbox_panels.Size = new System.Drawing.Size(645, 228);
            this.pbox_panels.TabIndex = 0;
            this.pbox_panels.TabStop = false;
            this.pbox_panels.Visible = false;
            this.pbox_panels.Paint += new System.Windows.Forms.PaintEventHandler(this.pbox_panels_Paint);
            // 
            // pbox_TopView
            // 
            this.pbox_TopView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_TopView.BackColor = System.Drawing.Color.White;
            this.pbox_TopView.Location = new System.Drawing.Point(0, 307);
            this.pbox_TopView.Name = "pbox_TopView";
            this.pbox_TopView.Size = new System.Drawing.Size(797, 282);
            this.pbox_TopView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_TopView.TabIndex = 4;
            this.pbox_TopView.TabStop = false;
            // 
            // TopViewPanelViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 590);
            this.Controls.Add(this.pbox_TopView);
            this.Controls.Add(this.panel_topviewer);
            this.Controls.Add(this.ts_TopViewPanelViewer);
            this.Name = "TopViewPanelViewer";
            this.Load += new System.EventHandler(this.TopViewPanelViewer_Load);
            this.SizeChanged += new System.EventHandler(this.TopViewPanelViewer_SizeChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopViewPanelViewer_MouseMove);
            this.ts_TopViewPanelViewer.ResumeLayout(false);
            this.ts_TopViewPanelViewer.PerformLayout();
            this.panel_topviewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_panels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_TopView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_TopViewPanelViewer;
        private System.Windows.Forms.Panel panel_topviewer;
        private System.Windows.Forms.PictureBox pbox_TopView;
        private System.Windows.Forms.PictureBox pbox_panels;
        private System.Windows.Forms.ToolStripButton ts_newButton;
    }
}