namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    partial class CasementPanelUC
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
            this.cmenu_casement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_casement.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_casement
            // 
            this.cmenu_casement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenu_casement.Name = "cmenu_casement";
            this.cmenu_casement.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // CasementPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Name = "CasementPanelUC";
            this.SizeChanged += new System.EventHandler(this.CasementPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CasementPanelUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CasementPanelUC_MouseClick);
            this.MouseEnter += new System.EventHandler(this.CasementPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CasementPanelUC_MouseLeave);
            this.cmenu_casement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_casement;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
