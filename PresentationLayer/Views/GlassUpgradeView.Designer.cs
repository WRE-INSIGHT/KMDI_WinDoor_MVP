namespace PresentationLayer.Views
{
    partial class GlassUpgradeView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Header = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glassUpgradDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glassUpgradDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(809, 114);
            this.panel_Header.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.glassUpgradDGV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 200);
            this.panel1.TabIndex = 1;
            // 
            // glassUpgradDGV
            // 
            this.glassUpgradDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.glassUpgradDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glassUpgradDGV.Location = new System.Drawing.Point(0, 0);
            this.glassUpgradDGV.Name = "glassUpgradDGV";
            this.glassUpgradDGV.Size = new System.Drawing.Size(809, 200);
            this.glassUpgradDGV.TabIndex = 0;
            // 
            // GlassUpgradeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Header);
            this.Name = "GlassUpgradeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glass Upgrade";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.glassUpgradDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView glassUpgradDGV;
    }
}