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
            this.lbl_Fixed = new System.Windows.Forms.Label();
            this.cmenu_fxd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_fxd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Fixed
            // 
            this.lbl_Fixed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Fixed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Fixed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Fixed.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fixed.Location = new System.Drawing.Point(5, 5);
            this.lbl_Fixed.Name = "lbl_Fixed";
            this.lbl_Fixed.Size = new System.Drawing.Size(140, 140);
            this.lbl_Fixed.TabIndex = 0;
            this.lbl_Fixed.Text = "F";
            this.lbl_Fixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Fixed.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_Fixed_Paint);
            this.lbl_Fixed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseClick);
            this.lbl_Fixed.MouseEnter += new System.EventHandler(this.FixedPanelUC_MouseEnter);
            this.lbl_Fixed.MouseLeave += new System.EventHandler(this.FixedPanelUC_MouseLeave);
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
            this.Controls.Add(this.lbl_Fixed);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "FixedPanelUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeChanged += new System.EventHandler(this.FixedPanelUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FixedPanelUC_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FixedPanelUC_MouseClick);
            this.MouseEnter += new System.EventHandler(this.FixedPanelUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FixedPanelUC_MouseLeave);
            this.cmenu_fxd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Fixed;
        private System.Windows.Forms.ContextMenuStrip cmenu_fxd;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
