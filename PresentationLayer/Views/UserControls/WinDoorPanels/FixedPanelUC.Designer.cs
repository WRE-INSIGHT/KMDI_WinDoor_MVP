﻿namespace PresentationLayer.Views.UserControls.WinDoorPanels
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
            this.overlapSashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_fxd.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_fxd
            // 
            this.cmenu_fxd.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenu_fxd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.overlapSashToolStripMenuItem});
            this.cmenu_fxd.Name = "cmenu_fxd";
            this.cmenu_fxd.Size = new System.Drawing.Size(143, 48);
            this.cmenu_fxd.Opening += new System.ComponentModel.CancelEventHandler(this.cmenu_fxd_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // overlapSashToolStripMenuItem
            // 
            this.overlapSashToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightToolStripMenuItem,
            this.leftToolStripMenuItem,
            this.bothToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.overlapSashToolStripMenuItem.Name = "overlapSashToolStripMenuItem";
            this.overlapSashToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.overlapSashToolStripMenuItem.Text = "Overlap Sash";
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.RightToolStripMenuItem_Click);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolStripMenuItem_Click);
            // 
            // bothToolStripMenuItem
            // 
            this.bothToolStripMenuItem.Name = "bothToolStripMenuItem";
            this.bothToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.bothToolStripMenuItem.Text = "Both";
            this.bothToolStripMenuItem.Click += new System.EventHandler(this.BothToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.NoneToolStripMenuItem_Click);
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
            this.SizeChanged += new System.EventHandler(this.FixedPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FixedPanelUC_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FixedPanelUC_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseDown);
            this.MouseEnter += new System.EventHandler(this.FixedPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FixedPanelUC_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FixedPanelUC_PreviewKeyDown);
            this.cmenu_fxd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmenu_fxd;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overlapSashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
    }
}
