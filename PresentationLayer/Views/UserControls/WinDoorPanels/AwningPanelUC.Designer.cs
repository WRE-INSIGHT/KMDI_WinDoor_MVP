namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class AwningPanelUC
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
            this.cmenu_awning = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_awning.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_awning
            // 
            this.cmenu_awning.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenu_awning.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.extensionToolStripMenuItem});
            this.cmenu_awning.Name = "cmenu_casement";
            this.cmenu_awning.Size = new System.Drawing.Size(126, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // extensionToolStripMenuItem
            // 
            this.extensionToolStripMenuItem.CheckOnClick = true;
            this.extensionToolStripMenuItem.Name = "extensionToolStripMenuItem";
            this.extensionToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.extensionToolStripMenuItem.Text = "Extension";
            this.extensionToolStripMenuItem.Click += new System.EventHandler(this.extensionToolStripMenuItem_Click);
            // 
            // AwningPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "AwningPanelUC";
            this.SizeChanged += new System.EventHandler(this.AwningPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AwningPanelUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AwningPanelUC_MouseClick);
            this.MouseEnter += new System.EventHandler(this.AwningPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AwningPanelUC_MouseLeave);
            this.cmenu_awning.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_awning;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extensionToolStripMenuItem;
    }
}
