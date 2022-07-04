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
            this.sashTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_casement.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_casement
            // 
            this.cmenu_casement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.sashTypeToolStripMenuItem});
            this.cmenu_casement.Name = "cmenu_casement";
            this.cmenu_casement.Size = new System.Drawing.Size(126, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sashTypeToolStripMenuItem
            // 
            this.sashTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noRightToolStripMenuItem,
            this.noLeftToolStripMenuItem,
            this.noBothToolStripMenuItem,
            this.fullToolStripMenuItem});
            this.sashTypeToolStripMenuItem.Name = "sashTypeToolStripMenuItem";
            this.sashTypeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sashTypeToolStripMenuItem.Text = "Sash Type";
            // 
            // noRightToolStripMenuItem
            // 
            this.noRightToolStripMenuItem.Name = "noRightToolStripMenuItem";
            this.noRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noRightToolStripMenuItem.Text = "No Right";
            this.noRightToolStripMenuItem.Click += new System.EventHandler(this.noRightToolStripMenuItem_Click);
            // 
            // noLeftToolStripMenuItem
            // 
            this.noLeftToolStripMenuItem.Name = "noLeftToolStripMenuItem";
            this.noLeftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noLeftToolStripMenuItem.Text = "No Left";
            this.noLeftToolStripMenuItem.Click += new System.EventHandler(this.noLeftToolStripMenuItem_Click);
            // 
            // noBothToolStripMenuItem
            // 
            this.noBothToolStripMenuItem.Name = "noBothToolStripMenuItem";
            this.noBothToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noBothToolStripMenuItem.Text = "No Both";
            this.noBothToolStripMenuItem.Click += new System.EventHandler(this.noBothToolStripMenuItem_Click);
            // 
            // fullToolStripMenuItem
            // 
            this.fullToolStripMenuItem.Name = "fullToolStripMenuItem";
            this.fullToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fullToolStripMenuItem.Text = "Full";
            this.fullToolStripMenuItem.Click += new System.EventHandler(this.fullToolStripMenuItem_Click);
            // 
            // CasementPanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "CasementPanelUC";
            this.SizeChanged += new System.EventHandler(this.CasementPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CasementPanelUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CasementPanelUC_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CasementPanelUC_MouseDown);
            this.MouseEnter += new System.EventHandler(this.CasementPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CasementPanelUC_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CasementPanelUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CasementPanelUC_MouseUp);
            this.cmenu_casement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_casement;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sashTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noBothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullToolStripMenuItem;
    }
}
