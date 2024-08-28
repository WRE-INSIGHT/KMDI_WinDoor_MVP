namespace PresentationLayer.Views.Costing_Head
{
    partial class FactorView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Factor = new System.Windows.Forms.DataGridView();
            this.cmenu_Factor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SearchFactor = new System.Windows.Forms.Button();
            this.txt_SearchFactor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Factor)).BeginInit();
            this.cmenu_Factor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Factor
            // 
            this.dgv_Factor.AllowUserToAddRows = false;
            this.dgv_Factor.AllowUserToDeleteRows = false;
            this.dgv_Factor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_Factor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Factor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Factor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Factor.ContextMenuStrip = this.cmenu_Factor;
            this.dgv_Factor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Factor.Location = new System.Drawing.Point(0, 36);
            this.dgv_Factor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_Factor.Name = "dgv_Factor";
            this.dgv_Factor.ReadOnly = true;
            this.dgv_Factor.RowHeadersWidth = 51;
            this.dgv_Factor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Factor.Size = new System.Drawing.Size(387, 576);
            this.dgv_Factor.TabIndex = 105;
            this.dgv_Factor.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Factor_RowPostPaint);
            // 
            // cmenu_Factor
            // 
            this.cmenu_Factor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenu_Factor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.cmenu_Factor.Name = "cmenu_Factor";
            this.cmenu_Factor.Size = new System.Drawing.Size(105, 28);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SearchFactor);
            this.panel1.Controls.Add(this.txt_SearchFactor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 36);
            this.panel1.TabIndex = 109;
            // 
            // btn_SearchFactor
            // 
            this.btn_SearchFactor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_SearchFactor.BackgroundImage = global::PresentationLayer.Properties.Resources.search_filled_100px;
            this.btn_SearchFactor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SearchFactor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SearchFactor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SearchFactor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchFactor.Location = new System.Drawing.Point(332, 0);
            this.btn_SearchFactor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SearchFactor.Name = "btn_SearchFactor";
            this.btn_SearchFactor.Size = new System.Drawing.Size(55, 36);
            this.btn_SearchFactor.TabIndex = 110;
            this.btn_SearchFactor.UseVisualStyleBackColor = false;
            this.btn_SearchFactor.Click += new System.EventHandler(this.btn_SearchFactor_Click);
            // 
            // txt_SearchFactor
            // 
            this.txt_SearchFactor.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_SearchFactor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchFactor.Location = new System.Drawing.Point(0, 0);
            this.txt_SearchFactor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SearchFactor.Name = "txt_SearchFactor";
            this.txt_SearchFactor.Size = new System.Drawing.Size(332, 34);
            this.txt_SearchFactor.TabIndex = 109;
            this.txt_SearchFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SearchFactor_KeyDown);
            // 
            // FactorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 612);
            this.Controls.Add(this.dgv_Factor);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FactorView";
            this.Load += new System.EventHandler(this.FactorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Factor)).EndInit();
            this.cmenu_Factor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Factor;
        private System.Windows.Forms.ContextMenuStrip cmenu_Factor;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_SearchFactor;
        private System.Windows.Forms.TextBox txt_SearchFactor;
    }
}