namespace PresentationLayer.Views.UserControls.Dividers
{
    partial class MullionUC
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
            this.cmenu_mullion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_mullion.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_mullion
            // 
            this.cmenu_mullion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenu_mullion.Name = "cmenu_mullion";
            this.cmenu_mullion.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MullionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MullionUC";
            this.Size = new System.Drawing.Size(26, 350);
            this.SizeChanged += new System.EventHandler(this.MullionUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MullionUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MullionUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MullionUC_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MullionUC_MouseUp);
            this.cmenu_mullion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_mullion;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
