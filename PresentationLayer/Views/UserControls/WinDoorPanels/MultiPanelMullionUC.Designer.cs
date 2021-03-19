namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class MultiPanelMullionUC
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
            this.flp_MultiMullion = new System.Windows.Forms.FlowLayoutPanel();
            this.cmenu_mulltiP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.divCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dividerEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_mulltiP.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_MultiMullion
            // 
            this.flp_MultiMullion.AllowDrop = true;
            this.flp_MultiMullion.BackColor = System.Drawing.SystemColors.Control;
            this.flp_MultiMullion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_MultiMullion.Location = new System.Drawing.Point(0, 0);
            this.flp_MultiMullion.Margin = new System.Windows.Forms.Padding(0);
            this.flp_MultiMullion.Name = "flp_MultiMullion";
            this.flp_MultiMullion.Size = new System.Drawing.Size(300, 300);
            this.flp_MultiMullion.TabIndex = 0;
            this.flp_MultiMullion.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_MultiMullion_DragDrop);
            this.flp_MultiMullion.DragOver += new System.Windows.Forms.DragEventHandler(this.flp_MultiMullion_DragOver);
            this.flp_MultiMullion.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_Multi_Paint);
            this.flp_MultiMullion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flp_MultiMullion_MouseDown);
            this.flp_MultiMullion.MouseEnter += new System.EventHandler(this.flp_MultiMullion_MouseEnter);
            this.flp_MultiMullion.MouseLeave += new System.EventHandler(this.flp_MultiMullion_MouseLeave);
            // 
            // cmenu_mulltiP
            // 
            this.cmenu_mulltiP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divCountToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.dividerEnabledToolStripMenuItem});
            this.cmenu_mulltiP.Name = "cmenu_mulltiP";
            this.cmenu_mulltiP.Size = new System.Drawing.Size(157, 92);
            // 
            // divCountToolStripMenuItem
            // 
            this.divCountToolStripMenuItem.Name = "divCountToolStripMenuItem";
            this.divCountToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.divCountToolStripMenuItem.Text = "Div-Count";
            this.divCountToolStripMenuItem.Click += new System.EventHandler(this.divCountToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // dividerEnabledToolStripMenuItem
            // 
            this.dividerEnabledToolStripMenuItem.Checked = true;
            this.dividerEnabledToolStripMenuItem.CheckOnClick = true;
            this.dividerEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dividerEnabledToolStripMenuItem.Name = "dividerEnabledToolStripMenuItem";
            this.dividerEnabledToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.dividerEnabledToolStripMenuItem.Text = "Divider Enabled";
            this.dividerEnabledToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dividerEnabledToolStripMenuItem_CheckedChanged);
            // 
            // MultiPanelMullionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flp_MultiMullion);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MultiPanelMullionUC";
            this.Size = new System.Drawing.Size(300, 300);
            this.SizeChanged += new System.EventHandler(this.MultiPanelMullionUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MultiPanelMullionUC_Paint);
            this.cmenu_mulltiP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_MultiMullion;
        private System.Windows.Forms.ContextMenuStrip cmenu_mulltiP;
        private System.Windows.Forms.ToolStripMenuItem divCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dividerEnabledToolStripMenuItem;
    }
}
