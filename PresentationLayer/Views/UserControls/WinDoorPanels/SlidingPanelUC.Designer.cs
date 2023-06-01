namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class SlidingPanelUC
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
            this.cmenu_sliding = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlapSashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_sliding.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_sliding
            // 
            this.cmenu_sliding.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.overlapSashToolStripMenuItem,
            this.addToScreenToolStripMenuItem});
            this.cmenu_sliding.Name = "cmenu_casement";
            this.cmenu_sliding.Size = new System.Drawing.Size(153, 92);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // overlapSashToolStripMenuItem
            // 
            this.overlapSashToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightToolStripMenuItem,
            this.LeftToolStripMenuItem,
            this.BothToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.overlapSashToolStripMenuItem.Name = "overlapSashToolStripMenuItem";
            this.overlapSashToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.overlapSashToolStripMenuItem.Text = "Overlap Sash";
            // 
            // RightToolStripMenuItem
            // 
            this.RightToolStripMenuItem.Name = "RightToolStripMenuItem";
            this.RightToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.RightToolStripMenuItem.Text = "Right";
            this.RightToolStripMenuItem.Click += new System.EventHandler(this.RightToolStripMenuItem_Click);
            // 
            // LeftToolStripMenuItem
            // 
            this.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem";
            this.LeftToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.LeftToolStripMenuItem.Text = "Left";
            this.LeftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolStripMenuItem_Click);
            // 
            // BothToolStripMenuItem
            // 
            this.BothToolStripMenuItem.Name = "BothToolStripMenuItem";
            this.BothToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.BothToolStripMenuItem.Text = "Both";
            this.BothToolStripMenuItem.Click += new System.EventHandler(this.BothToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // addToScreenToolStripMenuItem
            // 
            this.addToScreenToolStripMenuItem.Name = "addToScreenToolStripMenuItem";
            this.addToScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToScreenToolStripMenuItem.Text = "Add to Screen";
            this.addToScreenToolStripMenuItem.Visible = false;
            this.addToScreenToolStripMenuItem.Click += new System.EventHandler(this.addToScreenToolStripMenuItem_Click);
            // 
            // SlidingPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SlidingPanelUC";
            this.SizeChanged += new System.EventHandler(this.SlidingPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SlidingPanelUC_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SlidingPanelUC_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SlidingPanelUC_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SlidingPanelUC_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlidingPanelUC_MouseDown);
            this.MouseEnter += new System.EventHandler(this.SlidingPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SlidingPanelUC_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SlidingPanelUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SlidingPanelUC_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SlidingPanelUC_PreviewKeyDown);
            this.cmenu_sliding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_sliding;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overlapSashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToScreenToolStripMenuItem;
    }
}
