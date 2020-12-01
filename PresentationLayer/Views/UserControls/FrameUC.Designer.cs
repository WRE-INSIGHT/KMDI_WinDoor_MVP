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
            this.components = new System.ComponentModel.Container();
            this.pnl_inner = new System.Windows.Forms.Panel();
            this.cmenu_frame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_inner
            // 
            this.pnl_inner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_inner.Location = new System.Drawing.Point(26, 26);
            this.pnl_inner.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_inner.Name = "pnl_inner";
            this.pnl_inner.Size = new System.Drawing.Size(48, 48);
            this.pnl_inner.TabIndex = 0;
            this.pnl_inner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_inner_Paint);
            this.pnl_inner.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frame_MouseClick);
            this.pnl_inner.MouseEnter += new System.EventHandler(this.pnl_inner_MouseEnter);
            this.pnl_inner.MouseLeave += new System.EventHandler(this.pnl_inner_MouseLeave);
            // 
            // cmenu_frame
            // 
            this.cmenu_frame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenu_frame.Name = "cmenu_frame";
            this.cmenu_frame.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // FrameUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_inner);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FrameUC";
            this.Padding = new System.Windows.Forms.Padding(26);
            this.Size = new System.Drawing.Size(100, 100);
            this.Load += new System.EventHandler(this.FrameUC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frame_MouseClick);
            this.MouseEnter += new System.EventHandler(this.FrameUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FrameUC_MouseLeave);
            this.cmenu_frame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_inner;
        private System.Windows.Forms.ContextMenuStrip cmenu_frame;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
