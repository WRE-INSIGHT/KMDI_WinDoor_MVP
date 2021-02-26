namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class MultiPanelTransomUC
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
            this.flp_MultiTransom = new System.Windows.Forms.FlowLayoutPanel();
            this.cmenu_mulltiP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.divCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_mulltiP.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_MultiTransom
            // 
            this.flp_MultiTransom.AllowDrop = true;
            this.flp_MultiTransom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_MultiTransom.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_MultiTransom.Location = new System.Drawing.Point(0, 0);
            this.flp_MultiTransom.Margin = new System.Windows.Forms.Padding(0);
            this.flp_MultiTransom.Name = "flp_MultiTransom";
            this.flp_MultiTransom.Size = new System.Drawing.Size(300, 300);
            this.flp_MultiTransom.TabIndex = 1;
            this.flp_MultiTransom.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_MultiTransom_DragDrop);
            this.flp_MultiTransom.DragOver += new System.Windows.Forms.DragEventHandler(this.flp_MultiTransom_DragOver);
            this.flp_MultiTransom.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_MultiTransom_Paint);
            this.flp_MultiTransom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flp_MultiTransom_MouseDown);
            this.flp_MultiTransom.MouseEnter += new System.EventHandler(this.flp_MultiTransom_MouseEnter);
            this.flp_MultiTransom.MouseLeave += new System.EventHandler(this.flp_MultiTransom_MouseLeave);
            // 
            // cmenu_mulltiP
            // 
            this.cmenu_mulltiP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divCountToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmenu_mulltiP.Name = "cmenu_mulltiP";
            this.cmenu_mulltiP.Size = new System.Drawing.Size(130, 48);
            // 
            // divCountToolStripMenuItem
            // 
            this.divCountToolStripMenuItem.Name = "divCountToolStripMenuItem";
            this.divCountToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.divCountToolStripMenuItem.Text = "Div-Count";
            this.divCountToolStripMenuItem.Click += new System.EventHandler(this.divCountToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MultiPanelTransomUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flp_MultiTransom);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MultiPanelTransomUC";
            this.Size = new System.Drawing.Size(300, 300);
            this.SizeChanged += new System.EventHandler(this.MultiPanelTransomUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MultiPanelTransomUC_Paint);
            this.cmenu_mulltiP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_MultiTransom;
        private System.Windows.Forms.ContextMenuStrip cmenu_mulltiP;
        private System.Windows.Forms.ToolStripMenuItem divCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
