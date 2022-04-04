namespace PresentationLayer.Views.UserControls
{
    partial class ConcreteUC
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
            this.cmenu_concrete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_concrete.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu_concrete
            // 
            this.cmenu_concrete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenu_concrete.Name = "cmenu_frame";
            this.cmenu_concrete.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // ConcreteUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ConcreteUC";
            this.Size = new System.Drawing.Size(100, 100);
            this.Load += new System.EventHandler(this.ConcreteUC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConcreteUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConcreteUC_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ConcreteUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ConcreteUC_MouseLeave);
            this.cmenu_concrete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu_concrete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
