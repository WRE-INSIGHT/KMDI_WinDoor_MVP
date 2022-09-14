namespace PresentationLayer.Views.UserControls
{
    partial class MultiPanelPropertiesUC
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
            this.lbl_MultiPanelName = new System.Windows.Forms.Label();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_MultiPanelProperties = new System.Windows.Forms.Panel();
            this.cmenu_mpanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.glassBalancingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            this.panel1.SuspendLayout();
            this.cmenu_mpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_MultiPanelName
            // 
            this.lbl_MultiPanelName.AutoSize = true;
            this.lbl_MultiPanelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MultiPanelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MultiPanelName.Location = new System.Drawing.Point(3, 3);
            this.lbl_MultiPanelName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbl_MultiPanelName.Name = "lbl_MultiPanelName";
            this.lbl_MultiPanelName.Size = new System.Drawing.Size(109, 21);
            this.lbl_MultiPanelName.TabIndex = 0;
            this.lbl_MultiPanelName.Text = "MultiMullion_1";
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(3, 34);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(35, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // num_Width
            // 
            this.num_Width.Enabled = false;
            this.num_Width.Location = new System.Drawing.Point(3, 50);
            this.num_Width.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(135, 20);
            this.num_Width.TabIndex = 5;
            this.num_Width.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Location = new System.Drawing.Point(3, 75);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(38, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // num_Height
            // 
            this.num_Height.Enabled = false;
            this.num_Height.Location = new System.Drawing.Point(3, 91);
            this.num_Height.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(135, 20);
            this.num_Height.TabIndex = 7;
            this.num_Height.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_MultiPanelName);
            this.panel1.Controls.Add(this.lbl_Width);
            this.panel1.Controls.Add(this.lbl_Height);
            this.panel1.Controls.Add(this.num_Height);
            this.panel1.Controls.Add(this.num_Width);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 120);
            this.panel1.TabIndex = 8;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // pnl_MultiPanelProperties
            // 
            this.pnl_MultiPanelProperties.AutoSize = true;
            this.pnl_MultiPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MultiPanelProperties.Location = new System.Drawing.Point(0, 120);
            this.pnl_MultiPanelProperties.Name = "pnl_MultiPanelProperties";
            this.pnl_MultiPanelProperties.Padding = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.pnl_MultiPanelProperties.Size = new System.Drawing.Size(154, 9);
            this.pnl_MultiPanelProperties.TabIndex = 9;
            this.pnl_MultiPanelProperties.Click += new System.EventHandler(this.pnl_MultiPanelProperties_Click);
            // 
            // cmenu_mpanel
            // 
            this.cmenu_mpanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.glassBalancingToolStripMenuItem});
            this.cmenu_mpanel.Name = "cmenu_mpanel";
            this.cmenu_mpanel.Size = new System.Drawing.Size(157, 26);
            // 
            // glassBalancingToolStripMenuItem
            // 
            this.glassBalancingToolStripMenuItem.Name = "glassBalancingToolStripMenuItem";
            this.glassBalancingToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.glassBalancingToolStripMenuItem.Text = "Glass Balancing";
            this.glassBalancingToolStripMenuItem.Click += new System.EventHandler(this.glassBalancingToolStripMenuItem_Click);
            // 
            // MultiPanelPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_MultiPanelProperties);
            this.Controls.Add(this.panel1);
            this.Name = "MultiPanelPropertiesUC";
            this.Size = new System.Drawing.Size(154, 129);
            this.Load += new System.EventHandler(this.MultiPanelPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmenu_mpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_MultiPanelName;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_MultiPanelProperties;
        private System.Windows.Forms.ContextMenuStrip cmenu_mpanel;
        private System.Windows.Forms.ToolStripMenuItem glassBalancingToolStripMenuItem;
    }
}
