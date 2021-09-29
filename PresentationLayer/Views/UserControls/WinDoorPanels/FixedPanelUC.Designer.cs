namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class FixedPanelUC
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
            this.cmenu_fxd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_fxd.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_fxd
            // 
            this.cmenu_fxd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenu_fxd.Name = "cmenu_fxd";
            this.cmenu_fxd.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // FixedPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FixedPanelUC";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FixedPanelUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseClick);
            this.MouseEnter += new System.EventHandler(this.FixedPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FixedPanelUC_MouseLeave);
            this.cmenu_fxd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmenu_fxd;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
