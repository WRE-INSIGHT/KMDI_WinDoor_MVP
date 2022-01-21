namespace PresentationLayer.Views.UserControls
{
    partial class ControlsUC
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
            this.lblControlText = new System.Windows.Forms.Label();
            this.pnl_WinDoorPanel = new System.Windows.Forms.Panel();
            this.cmenu_ControlsUC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.divcountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iterationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_ControlsUC.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblControlText
            // 
            this.lblControlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblControlText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlText.Location = new System.Drawing.Point(0, 0);
            this.lblControlText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblControlText.Name = "lblControlText";
            this.lblControlText.Size = new System.Drawing.Size(84, 78);
            this.lblControlText.TabIndex = 3;
            this.lblControlText.Text = "Fixed";
            this.lblControlText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblControlText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblControlText_MouseClick);
            // 
            // pnl_WinDoorPanel
            // 
            this.pnl_WinDoorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_WinDoorPanel.Location = new System.Drawing.Point(84, 0);
            this.pnl_WinDoorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_WinDoorPanel.Name = "pnl_WinDoorPanel";
            this.pnl_WinDoorPanel.Size = new System.Drawing.Size(87, 78);
            this.pnl_WinDoorPanel.TabIndex = 4;
            // 
            // cmenu_ControlsUC
            // 
            this.cmenu_ControlsUC.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenu_ControlsUC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divcountToolStripMenuItem,
            this.iterationToolStripMenuItem});
            this.cmenu_ControlsUC.Name = "cmenu_ControlsUC";
            this.cmenu_ControlsUC.Size = new System.Drawing.Size(144, 52);
            // 
            // divcountToolStripMenuItem
            // 
            this.divcountToolStripMenuItem.Name = "divcountToolStripMenuItem";
            this.divcountToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.divcountToolStripMenuItem.Text = "Div-count";
            this.divcountToolStripMenuItem.Click += new System.EventHandler(this.divcountToolStripMenuItem_Click);
            // 
            // iterationToolStripMenuItem
            // 
            this.iterationToolStripMenuItem.Name = "iterationToolStripMenuItem";
            this.iterationToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.iterationToolStripMenuItem.Text = "Iteration";
            this.iterationToolStripMenuItem.Click += new System.EventHandler(this.iterationToolStripMenuItem_Click);
            // 
            // ControlsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblControlText);
            this.Controls.Add(this.pnl_WinDoorPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlsUC";
            this.Size = new System.Drawing.Size(171, 78);
            this.Load += new System.EventHandler(this.ControlsUC_Load);
            this.cmenu_ControlsUC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblControlText;
        private System.Windows.Forms.Panel pnl_WinDoorPanel;
        private System.Windows.Forms.ContextMenuStrip cmenu_ControlsUC;
        private System.Windows.Forms.ToolStripMenuItem divcountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iterationToolStripMenuItem;
    }
}
